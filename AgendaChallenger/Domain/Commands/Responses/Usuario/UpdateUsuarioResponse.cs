namespace AgendaChallenger.Domain.Commands.Responses.Usuario
{
    public class UpdateUsuarioResponse
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
