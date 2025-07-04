using AgendaChallenger.Domain.Commands.Requests.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using Data.Models;
using Data.Interfaces;
using Data.Repositories;
using GoogleCalendar;
using MediatR;

namespace AgendaChallenger.Domain.Handlers.Compromisso
{
    public class UpdateCompromissoHandler : IRequestHandler<UpdateCompromissoRequest, UpdateCompromissoResponse>
    {
        private readonly ICompromissoRepository _compromissoRepository;

        public UpdateCompromissoHandler(ICompromissoRepository compromissoRepository)
        {
            _compromissoRepository = compromissoRepository;
        }
        public async Task<UpdateCompromissoResponse> Handle(UpdateCompromissoRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateCompromissoResponse();

            // Cria um novo objeto compromisso com os dados da request
            var compromisso = new Data.Models.Compromisso(
                request.Id,
                request.Titulo ?? string.Empty,
                request.Descricao ?? string.Empty,
                request.DataInicio ?? DateTime.MinValue,
                request.DataFim ?? DateTime.MinValue,
                request.Localizacao ?? string.Empty,
                (int)(request.Status ?? request.Status)                // converte enum para int
            );
            compromisso.Ativo = true;
            compromisso.DataCriacao = DateTime.Now;

            // Atualiza o evento no Google Calendar com base no compromisso construído
            var calendarApi = await CalendarAPI.CriarInstanciaAsync();
            await calendarApi.AtualizarEventoAsync(request.Id.ToString(), compromisso);

            // Atualiza o compromisso no banco de dados
            var obj = await _compromissoRepository.Update(compromisso);

            // Preenche a resposta
            result.Id = obj.Id;
            result.Titulo = obj.Titulo;
            result.Descricao = obj.Descricao;
            result.DataInicio = obj.DataInicio;
            result.DataFim = obj.DataFim;
            result.Localizacao = obj.Localizacao;
            result.Status = obj.Status;
            result.DataCriacao = obj.DataCriacao;

            return result;
        }
    }
}
