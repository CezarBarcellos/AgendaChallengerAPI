namespace AgendaChallenger.Domain.Commands.Responses.Usuario
{
    public record GetUsuarioResponse
    {
        int Id { get; set; }
        string? Nome { get; set; }
        string? Email { get; set; }
    }
}
