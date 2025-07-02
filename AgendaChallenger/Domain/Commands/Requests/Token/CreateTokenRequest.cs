using AgendaChallenger.Domain.Commands.Responses.Token;
using MediatR;

namespace AgendaChallenger.Domain.Commands.Requests.Token
{
    public class CreateTokenRequest : IRequest<CreateTokenResponse>
    {
        public required string Nome { get; set; }
        public required string Senha { get; set; }
    }
}