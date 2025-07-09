namespace AgendaChallenger.Domain.Commands.Responses.Calendar
{
    public record ObtemFeriadosCalendarResponse
    {
        public IEnumerable<Data.Models.Compromisso>? lstFeriados { get; set; }
    }
}
