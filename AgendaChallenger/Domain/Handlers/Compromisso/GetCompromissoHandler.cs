using AgendaChallenger.Domain.Commands.Requests.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using MediatR;

namespace AgendaChallenger.Domain.Handlers.Compromisso
{
    public class GetCompromissoHandler : IRequestHandler<GetCompromissoRequest, GetCompromissoResponse>
    {
        public Task<GetCompromissoResponse> Handle(GetCompromissoRequest request, CancellationToken cancellationToken)
        {
            var result = new GetCompromissoResponse();            

            return Task.FromResult(result);
        }
    }
}
