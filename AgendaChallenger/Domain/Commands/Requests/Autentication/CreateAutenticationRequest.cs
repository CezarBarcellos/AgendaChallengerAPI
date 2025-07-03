using AgendaChallenger.Domain.Commands.Responses.Autentication;
using MediatR;

namespace AgendaChallenger.Domain.Commands.Requests.Autentication
{
    public class CreateAutenticationRequest : IRequest<CreateAutenticationResponse>
    {
        public required string Usuario { get; set; }
        public required string Senha { get; set; }
    }
}