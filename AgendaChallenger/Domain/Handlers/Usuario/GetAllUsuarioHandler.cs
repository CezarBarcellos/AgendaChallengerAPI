using AgendaChallenger.Domain.Commands.Requests.Usuario;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using MediatR;

namespace AgendaChallenger.Domain.Handlers
{
    public class GetAllUsuarioHandler : IRequestHandler<GetAllUsuarioRequest, GetAllUsuarioResponse>
    {
        public Task<GetAllUsuarioResponse> Handle(GetAllUsuarioRequest request, CancellationToken cancellationToken)
        {
            var result = new GetAllUsuarioResponse
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
