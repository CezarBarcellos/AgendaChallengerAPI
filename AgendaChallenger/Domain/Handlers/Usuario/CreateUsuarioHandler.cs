using AgendaChallenger.Domain.Commands.Requests.Usuario;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using Data.Interfaces;
using MediatR;
using AgendaChallenger.Domain.Utils;

namespace AgendaChallenger.Domain.Handlers
{
    public class CreateUsuarioHandler : IRequestHandler<CreateUsuarioRequest, CreateUsuarioResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public CreateUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Task<CreateUsuarioResponse> Handle(CreateUsuarioRequest request, CancellationToken cancellationToken)
        {
            Data.Models.Usuario usuario = new Data.Models.Usuario(request.Nome, request.Email, request.Senha, true);

            usuario.Senha = CryptoUtils.Encrypt(request.Senha);
            usuario.Ativo = true;
            usuario.DataCriacao = DateTime.Now;
            var obj = _usuarioRepository.Add(usuario);

            var result = new CreateUsuarioResponse();
            result.Id = obj.Result.Id;
            result.Nome = obj.Result.Nome;
            result.Email = obj.Result.Email;
            result.DataCriacao = obj.Result.DataCriacao;

            return Task.FromResult(result);
        }        
    }
}
