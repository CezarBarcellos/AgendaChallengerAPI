using AgendaChallenger.Domain.Commands.Requests.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using Data.Interfaces;
using Data.Repositories;
using GoogleCalendar;
using GoogleCalendar.Config;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AgendaChallenger.Domain.Handlers.Compromisso
{
    public class DeleteCompromissoHandler : IRequestHandler<DeleteCompromissoRequest, DeleteCompromissoResponse>
    {
        private readonly ICompromissoRepository _compromissoRepository;
        private readonly GoogleCalendarConfig _calendarConfig;

        public DeleteCompromissoHandler(ICompromissoRepository compromissoRepository, GoogleCalendarConfig calendarConfig)
        {
            _compromissoRepository = compromissoRepository;
            _calendarConfig = calendarConfig;
        }
        public async Task<DeleteCompromissoResponse> Handle(DeleteCompromissoRequest request, CancellationToken cancellationToken)
        {
            DeleteCompromissoResponse result = new DeleteCompromissoResponse();            

            var calendarApi = await CalendarAPI.CriarInstanciaAsync(_calendarConfig);
            await calendarApi.ExcluirEventoAsync(request.Id);

            var compromisso = _compromissoRepository.Get(request.Id, cancellationToken).Result;

            if (compromisso != null)
            {
                if (_compromissoRepository.Delete(compromisso).Result > 0)
                {
                    result.mensagem = "Removido com sucesso.";
                    Console.WriteLine($"Evento com ID '{request.Id}' foi excluído da base.");
                }
                else
                {
                    result.mensagem = "Falha ao remover Compromisso.";
                    Console.WriteLine($"Falha ao remover o Evento com ID '{request.Id}'.");
                }
            }
            else
            {
                result.mensagem = "Compromisso inexistente.";
                Console.WriteLine($"Compromisso inexistente com o ID '{request.Id}'.");
            }

            return Task.FromResult(result).Result;
        }
    }
}
