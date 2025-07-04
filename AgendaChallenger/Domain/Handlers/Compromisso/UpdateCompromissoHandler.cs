using AgendaChallenger.Domain.Commands.Requests.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using Data.Models;
using Data.Interfaces;
using Data.Repositories;
using GoogleCalendar;
using MediatR;
using GoogleCalendar.Config;

namespace AgendaChallenger.Domain.Handlers.Compromisso
{
    public class UpdateCompromissoHandler : IRequestHandler<UpdateCompromissoRequest, UpdateCompromissoResponse>
    {
        private readonly ICompromissoRepository _compromissoRepository;
        private readonly GoogleCalendarConfig _calendarConfig;

        public UpdateCompromissoHandler(ICompromissoRepository compromissoRepository, GoogleCalendarConfig calendarConfig)
        {
            _compromissoRepository = compromissoRepository;
            _calendarConfig = calendarConfig;
        }
        public async Task<UpdateCompromissoResponse> Handle(UpdateCompromissoRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateCompromissoResponse();
                        
            var compromisso = new Data.Models.Compromisso(
                request.Id,
                request.Titulo ?? string.Empty,
                request.Descricao ?? string.Empty,
                request.DataInicio ?? DateTime.MinValue,
                request.DataFim ?? DateTime.MinValue,
                request.Localizacao ?? string.Empty,
                (int)(request.Status ?? request.Status)
            );

            compromisso.Ativo = true;
            compromisso.DataAlteracao = DateTime.Now;
            compromisso.DataCriacao = DateTime.Now;

            var calendarApi = await CalendarAPI.CriarInstanciaAsync(_calendarConfig);
            await calendarApi.AtualizarEventoAsync(request.Id.ToString(), compromisso);
                        
            var obj = await _compromissoRepository.Update(compromisso);

            if (obj != null && !string.IsNullOrEmpty(obj.Id))
            {
                result.Id = obj.Id;
                result.Titulo = obj.Titulo;
                result.Descricao = obj.Descricao;
                result.DataInicio = obj.DataInicio;
                result.DataFim = obj.DataFim;
                result.Localizacao = obj.Localizacao;
                result.Status = obj.Status;
                result.DataCriacao = obj.DataCriacao;
                Console.WriteLine($"Evento com ID '{request.Id}' foi atualizado com sucesso a base.");
            }
            else
            {
                Console.WriteLine($"Falha ao atualizar o Evento com ID '{request.Id}' a base.");
            }

            return result;
        }
    }
}
