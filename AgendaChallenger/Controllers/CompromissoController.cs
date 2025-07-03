using AgendaChallenger.Domain.Commands.Requests.Compromisso;
using AgendaChallenger.Domain.Commands.Requests.Usuario;
using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using AgendaChallenger.Domain.Handlers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaChallenger.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("")]
    public class CompromissoController : Controller
    {
        [HttpGet]
        [Route("ObterCompromisso")]
        public Task<GetCompromissoResponse> Get([FromServices] IMediator mediator, int id)
        {
            var command = new GetCompromissoRequest { Id = id };
            return mediator.Send(command);
        }

        [HttpPost]
        [Route("ObterTodosCompromissos")]
        public Task<GetAllCompromissoResponse> GetAll([FromServices] IMediator mediator, [FromBody] GetAllCompromissoRequest command)
        {
            return mediator.Send(command);
        }

        [HttpPost]
        [Route("CriarCompromisso")]
        public Task<CreateCompromissoResponse> Create([FromServices]IMediator mediator, [FromBody]CreateCompromissoRequest command)
        {
            return mediator.Send(command);
        }

        [HttpPost]
        [Route("AtualizarCompromisso")]
        public Task<UpdateCompromissoResponse> Update([FromServices] IMediator mediator, [FromBody] UpdateCompromissoRequest command)
        {
            return mediator.Send(command);
        }

        [HttpDelete]
        [Route("RemoverCompromisso")]
        public Task<DeleteCompromissoResponse> Delete([FromServices] IMediator mediator, int id)
        {
            var command = new DeleteCompromissoRequest { Id = id };
            return mediator.Send(command);
        }
    }
}
