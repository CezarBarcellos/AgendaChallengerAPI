namespace AgendaChallenger.Domain.Commands.Responses.Usuario
{
    public record GetAllUsuarioResponse
    {
        public IEnumerable<Data.Models.Usuario>? lstUsuarios { get; set; }
    }
}
