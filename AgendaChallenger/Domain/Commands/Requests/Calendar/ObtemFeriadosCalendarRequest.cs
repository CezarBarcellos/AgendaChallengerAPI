using AgendaChallenger.Domain.Commands.Responses.Calendar;
using MediatR;

namespace AgendaChallenger.Domain.Commands.Requests.Calendar
{
    public class ObtemFeriadosCalendarRequest : IRequest<ObtemFeriadosCalendarResponse>
    {
        public required int Ano { get; set; }
    }
}