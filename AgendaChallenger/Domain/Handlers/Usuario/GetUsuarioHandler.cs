using AgendaChallenger.Domain.Commands.Requests.Usuario;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using Data.Abstractions;
using Data.Interfaces;
using MediatR;

namespace AgendaChallenger.Domain.Handlers
{
    public class GetUsuarioHandler : IRequestHandler<GetUsuarioRequest, GetUsuarioResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public GetUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Task<GetUsuarioResponse> Handle(GetUsuarioRequest request, CancellationToken cancellationToken)
        {
            GetUsuarioResponse result = new GetUsuarioResponse();
            var usuario = _usuarioRepository.Get(request.Id, cancellationToken).Result;

            if (usuario != null)
            {
                result = new GetUsuarioResponse
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    Ativo = usuario.Ativo,
                    DataCriacao = usuario.DataCriacao,
                    DataAlteracao = usuario.DataAlteracao
                };
            }

            return Task.FromResult(result);
        }
    }
}
