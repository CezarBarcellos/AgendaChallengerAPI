using AgendaChallenger.Domain.Commands.Requests.Calendar;
using AgendaChallenger.Domain.Commands.Responses.Calendar;
using Google.Apis.Calendar.v3.Data;
using GoogleCalendar;
using GoogleCalendar.Config;
using MediatR;

namespace AgendaChallenger.Domain.Handlers.Calendar
{
    public class ObtemFeriadosCalendarHandler : IRequestHandler<ObtemFeriadosCalendarRequest, ObtemFeriadosCalendarResponse>
    {
        private readonly GoogleCalendarConfig _calendarConfig;

        public ObtemFeriadosCalendarHandler(GoogleCalendarConfig calendarConfig)
        {
            _calendarConfig = calendarConfig;
        }
        public async Task<ObtemFeriadosCalendarResponse> Handle(ObtemFeriadosCalendarRequest request, CancellationToken cancellationToken)
        {
            ObtemFeriadosCalendarResponse result = new ObtemFeriadosCalendarResponse();

            var calendarApi = await CalendarAPI.CriarInstanciaAsync(_calendarConfig);
            var lstEvents = await calendarApi.ListarFeriadosNacionaisAsync(request.Ano);
            var lstEventos = Utils.Utils.LstEventToLstCompromisso(lstEvents);

            if (lstEventos != null && lstEventos.Count > 0)
            {
                result = new ObtemFeriadosCalendarResponse
                {
                    lstFeriados = lstEventos
                };
            }

            return Task.FromResult(result).Result;
        }
    }
}
