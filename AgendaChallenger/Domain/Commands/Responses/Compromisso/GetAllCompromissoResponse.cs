using AgendaChallenger.Entities;

namespace AgendaChallenger.Domain.Commands.Responses.Compromisso
{
    public record GetAllCompromissoResponse
    {
        Guid Id { get; set; }
        string? Titulo { get; set; }
        string? Descricao { get; set; }
        DateTime DataInicio { get; set; }
        DateTime DataFim { get; set; }
        Status Status { get; set; }
        DateTime DataCriacao { get; set; }
    }
}
