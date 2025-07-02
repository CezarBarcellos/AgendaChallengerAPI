using AgendaChallenger.Domain.Commands.Responses.Usuario;
using AgendaChallenger.Entities;
using MediatR;

namespace AgendaChallenger.Domain.Commands.Requests.Usuario
{
    public class CreateUsuarioRequest : IRequest<CreateUsuarioResponse>
    {
        public required string Id { get; set; }
        public required string Nome { get; set; }
    }
}