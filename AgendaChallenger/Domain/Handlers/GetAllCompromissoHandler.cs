using AgendaChallenger.Domain.Commands.Requests;
using AgendaChallenger.Domain.Commands.Responses;
using MediatR;

namespace AgendaChallenger.Domain.Handlers
{
    public class GetAllCompromissoHandler : IRequestHandler<GetAllCompromissoRequest, GetAllCompromissoResponse>
    {
        public Task<GetAllCompromissoResponse> Handle(GetAllCompromissoRequest request, CancellationToken cancellationToken)
        {
            var result = new GetAllCompromissoResponse
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
