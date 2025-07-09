namespace GoogleCalendar
{
    using Data.Models;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Calendar.v3;
    using Google.Apis.Calendar.v3.Data;
    using Google.Apis.Services;
    using Google.Apis.Util.Store;
    using GoogleCalendar.Config;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    public class CalendarAPI
    {
        private static readonly string[] Scopes = {
            CalendarService.Scope.Calendar,
        };

        private static readonly string ApplicationName = "Minha App Google Calendar";
        private readonly CalendarService service;
        private readonly GoogleCalendarConfig _config;

        private CalendarAPI(CalendarService service, GoogleCalendarConfig config)
        {
            this.service = service;
            _config = config;
        }

        public static async Task<CalendarAPI> CriarInstanciaAsync(GoogleCalendarConfig config)
        {
            var credential = await ObterCredenciaisAsync(config);

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return new CalendarAPI(service, config);
        }



        private static async Task<UserCredential> ObterCredenciaisAsync(GoogleCalendarConfig config)
        {
            if (!File.Exists(config.CredentialsPath))
                throw new FileNotFoundException("Arquivo de credenciais não encontrado.", config.CredentialsPath);

            using var stream = new FileStream(config.CredentialsPath, FileMode.Open, FileAccess.Read);
            string credPath = config.TokenPath ?? "token.json";

            return await GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.FromStream(stream).Secrets,
                Scopes,
                "user",
                CancellationToken.None,
                new FileDataStore(credPath, true)
            );
        }



        public async Task<IList<Event>> ListarEventosAsync(int maxResultados = 50)
        {
            var request = service.Events.List("primary");
            request.TimeMin = DateTime.Now;
            request.TimeMax = DateTime.Now.AddMonths(1);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.MaxResults = maxResultados;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            var events = await request.ExecuteAsync();

            if (events.Items == null || events.Items.Count == 0)
            {
                Console.WriteLine("Nenhum evento encontrado.");
                return new List<Event>();
            }

            // para depuração
            foreach (var evento in events.Items)
            {
                var inicio = evento.Start.DateTime ?? DateTime.Parse(evento.Start.Date);
                var fim = evento.End.DateTime ?? DateTime.Parse(evento.End.Date);

                Console.WriteLine($"- {evento.Summary}");
                Console.WriteLine($"  Início: {inicio}");
                Console.WriteLine($"  Fim: {fim}");
                Console.WriteLine($"  Local: {evento.Location}");
                Console.WriteLine($"  ID: {evento.Id}\n");
            }

            return events.Items;
        }


        public async Task<string> CriarEventoAsync(Compromisso compromisso)
        {
            var inicio = DateTime.Today.AddDays(1).AddHours(9);
            var fim = inicio.AddHours(1);

            var novoEvento = new Event()
            {
                Summary = compromisso.Titulo,
                Location = compromisso.Localizacao,
                Description = compromisso.Descricao,
                Start = new EventDateTime()
                {
                    DateTime = compromisso.DataInicio,
                    TimeZone = "America/Sao_Paulo"
                },
                End = new EventDateTime()
                {
                    DateTime = compromisso.DataFim,
                    TimeZone = "America/Sao_Paulo"
                },
                Attendees = new List<EventAttendee>()
                {
                    new EventAttendee() { Email = "cliente@email.com" }
                },
                Reminders = new Event.RemindersData()
                {
                    UseDefault = false,
                    Overrides = new List<EventReminder>()
                    {
                        new EventReminder() { Method = "email", Minutes = 30 },
                        new EventReminder() { Method = "popup", Minutes = 10 }
                    }
                }
            };

            try
            {
                var request = service.Events.Insert(novoEvento, "primary");
                var createdEvent = await request.ExecuteAsync().ConfigureAwait(false);

                Console.WriteLine("Evento criado: " + createdEvent.HtmlLink);
                return createdEvent.Id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao criar evento: " + ex.Message);
                throw;
            }
        }

        public async Task AtualizarEventoAsync(string eventId, Compromisso compromisso)
        {
            try
            {
                var evento = await service.Events.Get("primary", eventId).ExecuteAsync();

                
                if (evento.Start == null) evento.Start = new EventDateTime();
                if (evento.End == null) evento.End = new EventDateTime();

                
                if (!string.IsNullOrWhiteSpace(compromisso.Titulo))
                    evento.Summary = compromisso.Titulo;

                
                if (!string.IsNullOrWhiteSpace(compromisso.Descricao))
                    evento.Description = compromisso.Descricao;
                
                if (compromisso.DataInicio != DateTime.MinValue && compromisso.DataFim != DateTime.MinValue && compromisso.DataFim > compromisso.DataInicio)
                {
                    evento.Start.DateTime = compromisso.DataInicio;
                    evento.End.DateTime = compromisso.DataFim;
                }
                
                if (compromisso.Status == 0 || compromisso.Status == 1 || compromisso.Status == 2)
                {
                    evento.Status = compromisso.Status switch
                    {
                        0 => "cancelled",
                        1 => "confirmed",
                        2 => "tentative",
                        _ => evento.Status
                    };
                }

                var updateRequest = service.Events.Update(evento, "primary", eventId);
                var updatedEvent = await updateRequest.ExecuteAsync();

                Console.WriteLine("Evento atualizado: " + updatedEvent.HtmlLink);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Evento não atualizado: " + ex.Message);
                throw;
            }
        }

        public async Task<IList<Event>> ListarFeriadosNacionaisAsync(int ano)
        {
            string calendarioFeriadosId = "pt.brazilian#holiday@group.v.calendar.google.com";

            var request = service.Events.List(calendarioFeriadosId);
            request.TimeMin = new DateTime(ano, 1, 1);
            request.TimeMax = new DateTime(ano, 12, 31);
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            var events = await request.ExecuteAsync();

            if (events.Items == null || events.Items.Count == 0)
            {
                Console.WriteLine("Nenhum feriado encontrado.");
                return new List<Event>();
            }

            // Para depuração
            foreach (var evento in events.Items)
            {
                string data = evento.Start.Date ?? evento.Start.DateTime?.ToString();
                Console.WriteLine($"{data}: {evento.Summary}");
            }

            return events.Items;
        }


        public async Task ExcluirEventoAsync(string eventId)
        {
            await service.Events.Delete("primary", eventId).ExecuteAsync();
            Console.WriteLine($"Evento com ID '{eventId}' foi excluído.");
        }
    }
}
