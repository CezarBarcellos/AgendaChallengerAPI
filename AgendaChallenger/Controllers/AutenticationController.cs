using AgendaChallenger.Domain.Commands.Requests.Autentication;
using AgendaChallenger.Domain.Commands.Responses.Autentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AgendaChallenger.Controllers
{
    [ApiController]
    [Route("")]
    public class AutenticationController : Controller
    {
        [HttpPost]
        [Route("AutenticarUsuario")]
        public Task<CreateAutenticationResponse> AutenticarUsuario([FromServices] IMediator mediator, [FromBody] CreateAutenticationRequest command)
        {
            return mediator.Send(command);
        }
    }    
}
