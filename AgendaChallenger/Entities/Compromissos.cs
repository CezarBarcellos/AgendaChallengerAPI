namespace AgendaChallenger.Entities
{
    public class Compromissos
    {
        public required int Id { get; set; }
        public required string Titulo { get; set; }
        public required string Descricao { get; set; }
        public required DateTime DataInicio { get; set; }
        public required DateTime DataFim { get; set; }
        public string? Localizacao { get; set; }
        public required Status Status { get; set; }
    }

    public enum Status
    {
        Confirmado = 1,
        Pendente = 2,
        Cancelado = 3
    }
}
