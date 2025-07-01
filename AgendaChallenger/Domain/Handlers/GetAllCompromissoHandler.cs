using AgendaChallenger.Domain.Commands.Requests;
using AgendaChallenger.Domain.Commands.Responses;
using MediatR;

namespace AgendaChallenger.Domain.Handlers
{
    public class GetCompromissoHandler : IRequestHandler<CreateCompromissoRequest, CreateCompromissoResponse>
    {
        public Task<CreateCompromissoResponse> Handle(CreateCompromissoRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateCompromissoResponse
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
