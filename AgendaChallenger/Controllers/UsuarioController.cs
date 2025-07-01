using AgendaChallenger.Domain.Commands.Requests.Usuario;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaChallenger.Controllers
{
    [Authorize]
    [ApiController]
    [Route("")]
    public class UsuarioController : Controller
    {
        [HttpGet]
        [Route("ObterUsuario")]
        public Task<GetUsuarioResponse> Get([FromServices] IMediator mediator, [FromBody] GetUsuarioRequest command)
        {
            return mediator.Send(command);
        }

        [HttpGet]
        [Route("ObterTodosUsuarios")]
        public Task<GetAllUsuarioResponse> GetAll([FromServices] IMediator mediator, [FromBody] GetAllUsuarioRequest command)
        {
            return mediator.Send(command);
        }

        [HttpPost]
        [Route("CriarUsuario")]
        public Task<CreateUsuarioResponse> Create([FromServices] IMediator mediator, [FromBody] CreateUsuarioRequest command)
        {
            return mediator.Send(command);
        }

        [HttpPost]
        [Route("AtualizarUsuario")]
        public Task<UpdateUsuarioResponse> Update([FromServices] IMediator mediator, [FromBody] UpdateUsuarioRequest command)
        {
            return mediator.Send(command);
        }

        [HttpDelete]
        [Route("RemoverUsuario")]
        public Task<DeleteUsuarioResponse> Delete([FromServices] IMediator mediator, [FromBody] DeleteUsuarioRequest command)
        {
            return mediator.Send(command);
        }
    }
}
