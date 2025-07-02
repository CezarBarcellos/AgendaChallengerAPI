namespace AgendaChallenger.Entities
{
    public class Usuario
    {
        public required string Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required bool Ativo { get; set; }
        public required DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
