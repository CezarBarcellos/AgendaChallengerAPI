using AgendaChallenger.Domain.Commands.Requests.Usuario;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using AutoMapper;
using Data.Abstractions;
using Data.Interfaces;
using MediatR;

namespace AgendaChallenger.Domain.Handlers.Usuario
{
    public class DeleteUsuarioHandler : IRequestHandler<DeleteUsuarioRequest, DeleteUsuarioResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        public DeleteUsuarioHandler(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public Task<DeleteUsuarioResponse> Handle(DeleteUsuarioRequest request, CancellationToken cancellationToken)
        {
            DeleteUsuarioResponse result = new DeleteUsuarioResponse();
             var usuario = _usuarioRepository.Get(request.Id, cancellationToken).Result;

            if(usuario != null)
            {
                if(_usuarioRepository.Delete(usuario).Result > 0)
                {
                    result.mensagem = "Removido com sucesso.";
                }
                else
                {
                    result.mensagem = "Falha ao remover Usuário.";
                }
            }
            else
            {
                result.mensagem = "Usuário inexistente.";
            }
                        
            return Task.FromResult(result);
        }
    }
}
