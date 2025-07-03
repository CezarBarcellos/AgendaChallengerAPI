using AgendaChallenger.Authorization;
using AgendaChallenger.Domain.Commands.Requests.Autentication;
using AgendaChallenger.Domain.Commands.Responses.Autentication;
using AgendaChallenger.Domain.Interfaces;
using AgendaChallenger.Domain.Utils;
using Data.Abstractions;
using Data.Interfaces;
using Data.Repositories;
using MediatR;

namespace AgendaChallenger.Domain.Handlers
{
    public class CreateAutenticationHandler : IRequestHandler<CreateAutenticationRequest, CreateAutenticationResponse>
    {        
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _usuarioRepository;
        public CreateAutenticationHandler(IConfiguration configuration, IUsuarioRepository usuarioRepository)
        {
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
        }
        public Task<CreateAutenticationResponse> Handle(CreateAutenticationRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateAutenticationResponse { Sucesso = false };
            string senhaEncrypted = CryptoUtils.Encrypt(request.Senha);
            var usuario = _usuarioRepository.GetByToken(request.Usuario, senhaEncrypted).Result;
            if (usuario != null)
            {
                result.Sucesso = true;                
            }

            return Task.FromResult(result);
        }
    }
}
