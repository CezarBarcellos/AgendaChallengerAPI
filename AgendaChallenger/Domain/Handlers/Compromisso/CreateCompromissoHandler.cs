using AgendaChallenger.Domain.Commands.Requests.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using Data.Interfaces;
using GoogleCalendar;
using GoogleCalendar.Config;
using MediatR;

namespace AgendaChallenger.Domain.Handlers.Compromisso
{
    public class CreateCompromissoHandler : IRequestHandler<CreateCompromissoRequest, CreateCompromissoResponse>
    {
        private readonly ICompromissoRepository _compromissoRepository;
        private readonly GoogleCalendarConfig _calendarConfig;

        public CreateCompromissoHandler(ICompromissoRepository compromissoRepository, GoogleCalendarConfig calendarConfig)
        {
            _compromissoRepository = compromissoRepository;
            _calendarConfig = calendarConfig;
        }
        public async Task<CreateCompromissoResponse> Handle(CreateCompromissoRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateCompromissoResponse();
            Data.Models.Compromisso compromisso = new Data.Models.Compromisso(string.Empty, request.Titulo, request.Descricao, request.DataInicio, request.DataFim, request.Localizacao, request.Status);

            var calendarApi = await CalendarAPI.CriarInstanciaAsync(_calendarConfig);
            var id = await calendarApi.CriarEventoAsync(compromisso);

            compromisso.Ativo = true;
            compromisso.Id = id;
            compromisso.DataCriacao = DateTime.Now;
            var obj = _compromissoRepository.Add(compromisso).Result;

            if (obj != null && !string.IsNullOrEmpty(obj.Id))
            {
                result = new CreateCompromissoResponse();
                result.Id = obj.Id;
                result.Titulo = obj.Titulo;
                result.Descricao = obj.Descricao;
                result.DataInicio = obj.DataInicio;
                result.DataFim = obj.DataFim;
                result.Localizacao = obj.Localizacao;
                result.Status = obj.Status;
                result.DataCriacao = obj.DataCriacao;
                Console.WriteLine($"Evento com ID '{id}' foi adicionado com sucesso a base.");
            }
            else
            {
                Console.WriteLine($"Falha ao adicionar o Evento com ID '{id}' a base.");
            }

            return Task.FromResult(result).Result;
        }
    }
}
