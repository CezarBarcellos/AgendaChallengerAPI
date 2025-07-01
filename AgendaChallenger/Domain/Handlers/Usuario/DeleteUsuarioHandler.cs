using AgendaChallenger.Domain.Commands.Requests.Usuario;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using MediatR;

namespace AgendaChallenger.Domain.Handlers.Usuario
{
    public class DeleteUsuarioHandler : IRequestHandler<DeleteUsuarioRequest, DeleteUsuarioResponse>
    {
        public Task<DeleteUsuarioResponse> Handle(DeleteUsuarioRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteUsuarioResponse
            {
                Id = new Guid(),
                Titulo = request.Titulo,
                DataInicio = request.DataInicio,
                DataFim = request.DataFim,
                DataCriacao = DateTime.Now
            };

            return Task.FromResult(result);
        }
    }
}
