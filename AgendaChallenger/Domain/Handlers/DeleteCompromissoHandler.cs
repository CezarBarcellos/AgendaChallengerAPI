using AgendaChallenger.Domain.Commands.Requests;
using AgendaChallenger.Domain.Commands.Responses;
using MediatR;

namespace AgendaChallenger.Domain.Handlers
{
    public class DeleteCompromissoHandler : IRequestHandler<DeleteCompromissoRequest, DeleteCompromissoResponse>
    {
        public Task<DeleteCompromissoResponse> Handle(DeleteCompromissoRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteCompromissoResponse
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
