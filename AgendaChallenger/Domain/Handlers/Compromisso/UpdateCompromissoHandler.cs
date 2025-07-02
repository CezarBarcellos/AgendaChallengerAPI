using AgendaChallenger.Domain.Commands.Requests.Compromisso;
using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using MediatR;

namespace AgendaChallenger.Domain.Handlers.Compromisso
{
    public class UpdateCompromissoHandler : IRequestHandler<UpdateCompromissoRequest, UpdateCompromissoResponse>
    {
        public Task<UpdateCompromissoResponse> Handle(UpdateCompromissoRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateCompromissoResponse();

            return Task.FromResult(result);
        }
    }
}
