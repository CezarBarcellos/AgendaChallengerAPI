using AgendaChallenger.Domain.Commands.Requests.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using Data.Interfaces;
using Data.Repositories;
using GoogleCalendar;
using MediatR;

namespace AgendaChallenger.Domain.Handlers.Compromisso
{
    public class CreateCompromissoHandler : IRequestHandler<CreateCompromissoRequest, CreateCompromissoResponse>
    {
        private readonly ICompromissoRepository _compromissoRepository;

        public CreateCompromissoHandler(ICompromissoRepository compromissoRepository)
        {
            _compromissoRepository = compromissoRepository;
        }
        public async Task<CreateCompromissoResponse> Handle(CreateCompromissoRequest request, CancellationToken cancellationToken)
        {
            Data.Models.Compromisso compromisso = new Data.Models.Compromisso(request.Id, request.Titulo, request.Descricao, request.DataInicio, request.DataFim, request.Localizacao, request.Status);

            var calendarApi = await CalendarAPI.CriarInstanciaAsync();
            var id = await calendarApi.CriarEventoAsync(compromisso);

            compromisso.Ativo = true;
            compromisso.DataCriacao = DateTime.Now;
            var obj = _compromissoRepository.Add(compromisso);

            var result = new CreateCompromissoResponse();
            result.Id = obj.Result.Id;
            result.Titulo = obj.Result.Titulo;
            result.Descricao = obj.Result.Descricao;
            result.DataInicio = obj.Result.DataInicio;
            result.DataFim = obj.Result.DataFim;
            result.Localizacao = obj.Result.Localizacao;
            result.Status = obj.Result.Status;
            result.DataCriacao = obj.Result.DataCriacao;

            return Task.FromResult(result).Result;
        }
    }
}
