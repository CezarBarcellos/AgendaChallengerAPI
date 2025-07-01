using AgendaChallenger.Domain.Commands.Requests;
using AgendaChallenger.Domain.Commands.Responses;
using MediatR;

namespace AgendaChallenger.Domain.Handlers
{
    public class GetCompromissoHandler : IRequestHandler<GetCompromissoRequest, GetCompromissoResponse>
    {
        public Task<GetCompromissoResponse> Handle(GetCompromissoRequest request, CancellationToken cancellationToken)
        {
            var result = new GetCompromissoResponse
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
