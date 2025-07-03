using AgendaChallenger.Domain.Commands.Requests.Token;
using AgendaChallenger.Domain.Commands.Responses.Token;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AgendaChallenger.Controllers
{
    [ApiController]
    [Route("")]
    public class AuthorizationController : Controller
    {
        [HttpPost]
        [Route("Login")]
        public Task<CreateTokenResponse> GetToken([FromServices] IMediator mediator, [FromBody] CreateTokenRequest command)
        {
            return mediator.Send(command);
        }
    }
}
