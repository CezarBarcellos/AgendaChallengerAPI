namespace AgendaChallenger.Domain.Commands.Responses.Usuario
{
    public class CreateUsuarioResponse
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
