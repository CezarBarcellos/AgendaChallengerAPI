using AgendaChallenger.Domain.Commands.Requests.Usuario;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using MediatR;

namespace AgendaChallenger.Domain.Handlers
{
    public class GetAllUsuarioHandler : IRequestHandler<GetAllUsuarioRequest, GetAllUsuarioResponse>
    {
        public Task<GetAllUsuarioResponse> Handle(GetAllUsuarioRequest request, CancellationToken cancellationToken)
        {
            var result = new GetAllUsuarioResponse();

            return Task.FromResult(result);
        }
    }
}
