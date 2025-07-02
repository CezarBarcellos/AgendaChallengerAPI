using AgendaChallenger.Domain.Commands.Responses.Usuario;
using MediatR;

namespace AgendaChallenger.Domain.Commands.Requests.Usuario
{
    public class UpdateUsuarioRequest : IRequest<UpdateUsuarioResponse>
    {
        public required string Id { get; set; }
        public required string Nome { get; set; }
    }
}