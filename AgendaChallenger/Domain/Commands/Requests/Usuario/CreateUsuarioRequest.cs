using AgendaChallenger.Domain.Commands.Responses.Usuario;
using MediatR;

namespace AgendaChallenger.Domain.Commands.Requests.Usuario
{
    public class CreateUsuarioRequest : IRequest<CreateUsuarioResponse>
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Localizacao { get; set; }
        //public Status Status { get; set; }
    }
}