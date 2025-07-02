using AgendaChallenger.Domain.Commands.Requests.Usuario;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using AgendaChallenger.Domain.Utils;
using Data.Interfaces;
using MediatR;

namespace AgendaChallenger.Domain.Handlers
{
    public class UpdateUsuarioHandler : IRequestHandler<UpdateUsuarioRequest, UpdateUsuarioResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UpdateUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Task<UpdateUsuarioResponse> Handle(UpdateUsuarioRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateUsuarioResponse();
            var usuario = _usuarioRepository.Get(request.Id, cancellationToken).Result;

            if (usuario != null)
            {
                usuario.Senha = CryptoUtils.Encrypt(request.Senha);
                usuario.Ativo = request.Ativo;
                usuario.DataAlteracao = DateTime.Now;
                usuario.Nome = request.Nome;
                usuario.Email = request.Email;
                
                var obj = _usuarioRepository.Update(usuario);
                                
                result.Id = obj.Result.Id;
                result.Nome = obj.Result.Nome;
                result.Email = obj.Result.Email;
                result.DataAlteracao = obj.Result.DataAlteracao;
            }

            return Task.FromResult(result);
        }
    }
}
