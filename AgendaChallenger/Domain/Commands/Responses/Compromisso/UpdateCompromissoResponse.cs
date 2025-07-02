using AgendaChallenger.Entities;

namespace AgendaChallenger.Domain.Commands.Responses.Compromisso
{
    public class UpdateCompromissoResponse
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Status Status { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
