using AgendaChallenger.Domain.Commands.Requests.Usuario;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using MediatR;

namespace AgendaChallenger.Domain.Handlers
{
    public class UpdateUsuarioHandler : IRequestHandler<UpdateUsuarioRequest, UpdateUsuarioResponse>
    {
        public Task<UpdateUsuarioResponse> Handle(UpdateUsuarioRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateUsuarioResponse
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
