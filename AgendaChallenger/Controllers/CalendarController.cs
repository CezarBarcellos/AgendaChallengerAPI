using AgendaChallenger.Domain.Commands.Requests.Calendar;
using AgendaChallenger.Domain.Commands.Responses.Calendar;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaChallenger.Controllers
{
    [Authorize]
    [ApiController]
    [Route("")]
    public class CalendarController : Controller
    {
        [HttpGet]
        [Route("ObterFeriados")]
        public Task<ObtemFeriadosCalendarResponse> ObterFeriados([FromServices] IMediator mediator, int ano)
        {
            var command = new ObtemFeriadosCalendarRequest { Ano = ano };
            return mediator.Send(command);
        }
    }
}
