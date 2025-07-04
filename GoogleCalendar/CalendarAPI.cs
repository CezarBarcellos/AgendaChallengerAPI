namespace GoogleCalendar
{
    using Data.Models;
    using Google.Apis.Auth.OAuth2;
    using Google.Apis.Calendar.v3;
    using Google.Apis.Calendar.v3.Data;
    using Google.Apis.Services;
    using Google.Apis.Util.Store;
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

        private CalendarAPI(CalendarService service)
        {
            this.service = service;
        }

        public static async Task<CalendarAPI> CriarInstanciaAsync()
        {
            var credential = await ObterCredenciaisAsync();

            var service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            return new CalendarAPI(service);
        }

        private static async Task<UserCredential> ObterCredenciaisAsync()
        {
            using var stream = new FileStream("C:\\Users\\Cezar\\source\\repos\\AgendaChallengerAPI\\GoogleCalendar\\credentials.json", FileMode.Open, FileAccess.Read);
            string credPath = "token.json";

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

            // Impressão no console para depuração
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

                // Garantir que Start e End existam
                if (evento.Start == null) evento.Start = new EventDateTime();
                if (evento.End == null) evento.End = new EventDateTime();

                // Validar datas
                if (compromisso.DataInicio == DateTime.MinValue || compromisso.DataFim == DateTime.MinValue)
                    throw new ArgumentException("Datas inválidas.");

                if (compromisso.DataFim <= compromisso.DataInicio)
                    throw new ArgumentException("DataFim deve ser maior que DataInicio.");

                evento.Summary = compromisso.Titulo;
                evento.Description = compromisso.Descricao;
                evento.Start.DateTime = compromisso.DataInicio;
                evento.End.DateTime = compromisso.DataFim;

                evento.Status = compromisso.Status switch
                {
                    0 => "cancelled",
                    1 => "confirmed",
                    2 => "tentative",
                    _ => "confirmed"
                };

                var updateRequest = service.Events.Update(evento, "primary", eventId);
                var updatedEvent = await updateRequest.ExecuteAsync();
                Console.WriteLine("Evento atualizado: " + updatedEvent.HtmlLink);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Evento não atualizado: " + ex.Message);
                throw; // Opcional: relança para tratamento externo
            }
        }

        public async Task ExcluirEventoAsync(string eventId)
        {
            await service.Events.Delete("primary", eventId).ExecuteAsync();
            Console.WriteLine($"Evento com ID '{eventId}' foi excluído.");
        }
    }
}
