using AgendaChallenger.Domain.Commands.Requests.Usuario;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using MediatR;

namespace AgendaChallenger.Domain.Handlers
{
    public class CreateUsuarioHandler : IRequestHandler<CreateUsuarioRequest, CreateUsuarioResponse>
    {
        public Task<CreateUsuarioResponse> Handle(CreateUsuarioRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateUsuarioResponse
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
