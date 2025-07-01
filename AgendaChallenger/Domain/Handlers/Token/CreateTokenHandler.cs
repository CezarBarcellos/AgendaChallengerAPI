using AgendaChallenger.Domain.Commands.Requests.Token;
using AgendaChallenger.Domain.Commands.Responses.Token;
using MediatR;

namespace AgendaChallenger.Domain.Handlers
{
    public class CreateTokenHandler : IRequestHandler<CreateTokenRequest, CreateTokenResponse>
    {
        public Task<CreateTokenResponse> Handle(CreateTokenRequest request, CancellationToken cancellationToken)
        {


            var result = new CreateTokenResponse
            {
                Token = ""
            };

            return Task.FromResult(result);
        }
    }
}
