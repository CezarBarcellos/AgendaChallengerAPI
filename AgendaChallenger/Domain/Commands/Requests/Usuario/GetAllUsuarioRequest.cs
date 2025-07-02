using AgendaChallenger.Domain.Commands.Responses.Usuario;
using MediatR;

namespace AgendaChallenger.Domain.Commands.Requests.Usuario
{
    public class GetAllUsuarioRequest : IRequest<GetAllUsuarioResponse>
    {
        public DateTime DataCriacao { get; set; }
    }
}