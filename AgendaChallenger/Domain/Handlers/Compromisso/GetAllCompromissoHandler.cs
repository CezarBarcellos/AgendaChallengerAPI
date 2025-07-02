using AgendaChallenger.Domain.Commands.Requests.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using MediatR;

namespace AgendaChallenger.Domain.Handlers.Compromisso
{
    public class GetAllCompromissoHandler : IRequestHandler<GetAllCompromissoRequest, GetAllCompromissoResponse>
    {
        public Task<GetAllCompromissoResponse> Handle(GetAllCompromissoRequest request, CancellationToken cancellationToken)
        {
            var result = new GetAllCompromissoResponse();

            return Task.FromResult(result);
        }
    }
}
