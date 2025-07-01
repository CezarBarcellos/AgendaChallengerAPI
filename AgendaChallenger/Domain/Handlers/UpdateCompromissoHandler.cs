using AgendaChallenger.Domain.Commands.Requests;
using AgendaChallenger.Domain.Commands.Responses;
using MediatR;

namespace AgendaChallenger.Domain.Handlers
{
    public class UpdateCompromissoHandler : IRequestHandler<UpdateCompromissoRequest, UpdateCompromissoResponse>
    {
        public Task<UpdateCompromissoResponse> Handle(UpdateCompromissoRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateCompromissoResponse
            {
                Id = new Guid(),
                Titulo = request.Titulo,
                DataInicio = request.DataInicio,
                DataFim = request.DataFim,
                DataCriacao = DateTime.Now
            };

            return Task.FromResult(result);
        }
    }
}
