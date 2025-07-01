using AgendaChallenger.Domain.Commands.Requests;
using AgendaChallenger.Domain.Commands.Responses;
using AgendaChallenger.Domain.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AgendaChallenger.Controllers
{
    [ApiController]
    [Route("")]
    public class CompromissoController : Controller
    {
        [HttpGet]
        [Route("Obter")]
        public Task<GetCompromissoResponse> Get([FromServices] IMediator mediator, [FromBody] GetCompromissoRequest command)
        {
            return mediator.Send(command);
        }

        [HttpGet]
        [Route("ObterTodos")]
        public Task<GetAllCompromissoResponse> GetAll([FromServices] IMediator mediator, [FromBody] GetAllCompromissoRequest command)
        {
            return mediator.Send(command);
        }

        [HttpPost]
        [Route("Criar")]
        public Task<CreateCompromissoResponse> Create([FromServices]IMediator mediator, [FromBody]CreateCompromissoRequest command)
        {
            return mediator.Send(command);
        }

        [HttpPost]
        [Route("Atualizar")]
        public Task<UpdateCompromissoResponse> Update([FromServices] IMediator mediator, [FromBody] UpdateCompromissoRequest command)
        {
            return mediator.Send(command);
        }

        [HttpDelete]
        [Route("Remover")]
        public Task<DeleteCompromissoResponse> Delete([FromServices] IMediator mediator, [FromBody] DeleteCompromissoRequest command)
        {
            return mediator.Send(command);
        }
    }
}
