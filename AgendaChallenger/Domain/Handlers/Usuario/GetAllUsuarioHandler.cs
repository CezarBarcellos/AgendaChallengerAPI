using AgendaChallenger.Domain.Commands.Requests.Usuario;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using Data.Interfaces;
using MediatR;

namespace AgendaChallenger.Domain.Handlers
{
    public class GetAllUsuarioHandler : IRequestHandler<GetAllUsuarioRequest, GetAllUsuarioResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public GetAllUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Task<GetAllUsuarioResponse> Handle(GetAllUsuarioRequest request, CancellationToken cancellationToken)
        {
            GetAllUsuarioResponse result = new GetAllUsuarioResponse();
            var lstUsuario = _usuarioRepository.GetAll(cancellationToken).Result;

            if (lstUsuario != null && lstUsuario.Count > 0 )
            {
                result = new GetAllUsuarioResponse
                {
                    lstUsuarios = lstUsuario
                };
            }

            return Task.FromResult(result);
        }
    }
}
