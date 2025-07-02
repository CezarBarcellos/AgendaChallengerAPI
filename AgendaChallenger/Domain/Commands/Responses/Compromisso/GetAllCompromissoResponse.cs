namespace AgendaChallenger.Domain.Commands.Responses.Compromisso
{
    public record GetAllCompromissoResponse
    {
        public IEnumerable<Data.Models.Compromisso>? lstCompromissos { get; set; }
    }
}
