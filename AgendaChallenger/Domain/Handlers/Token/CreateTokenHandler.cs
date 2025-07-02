using AgendaChallenger.Authorization;
using AgendaChallenger.Domain.Commands.Requests.Token;
using AgendaChallenger.Domain.Commands.Responses.Token;
using AgendaChallenger.Domain.Interfaces;
using AgendaChallenger.Domain.Utils;
using Data.Abstractions;
using Data.Interfaces;
using Data.Repositories;
using MediatR;

namespace AgendaChallenger.Domain.Handlers
{
    public class CreateTokenHandler : IRequestHandler<CreateTokenRequest, CreateTokenResponse>
    {
        private readonly ITokenProvider _tokenProvider;
        private readonly IConfiguration _configuration;
        private readonly IUsuarioRepository _usuarioRepository;
        public CreateTokenHandler(ITokenProvider tokenProvider, IConfiguration configuration, IUsuarioRepository usuarioRepository)
        {
            _tokenProvider = tokenProvider;
            _configuration = configuration;
            _usuarioRepository = usuarioRepository;
        }
        public Task<CreateTokenResponse> Handle(CreateTokenRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateTokenResponse { Token = string.Empty };
            string senhaEncrypted = CryptoUtils.Encrypt(request.Senha);
            var usuario = _usuarioRepository.GetByToken(request.Nome, senhaEncrypted).Result;
            if (usuario != null)
            {
                string token = _tokenProvider.Create(usuario);

                result = new CreateTokenResponse
                {
                    Token = "Bearer " + token
                };
            }

            return Task.FromResult(result);
        }
    }
}
