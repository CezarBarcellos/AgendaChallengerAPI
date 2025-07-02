namespace AgendaChallenger.Domain.Commands.Responses.Usuario
{
    public record GetAllUsuarioResponse
    {
        int Id { get; set; }
        string? Nome { get; set; }
        string? Email { get; set; }
    }
}
