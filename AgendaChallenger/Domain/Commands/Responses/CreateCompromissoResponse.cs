namespace AgendaChallenger.Domain.Commands.Responses
{
    public class CreateCompromissoResponse
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        //public Status Status { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
