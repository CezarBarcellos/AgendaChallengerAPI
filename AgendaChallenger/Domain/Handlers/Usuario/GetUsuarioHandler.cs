using AgendaChallenger.Domain.Commands.Requests.Usuario;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using MediatR;

namespace AgendaChallenger.Domain.Handlers
{
    public class GetUsuarioHandler : IRequestHandler<GetUsuarioRequest, GetUsuarioResponse>
    {
        public Task<GetUsuarioResponse> Handle(GetUsuarioRequest request, CancellationToken cancellationToken)
        {
            var result = new GetUsuarioResponse();

            return Task.FromResult(result);
        }
    }
}
