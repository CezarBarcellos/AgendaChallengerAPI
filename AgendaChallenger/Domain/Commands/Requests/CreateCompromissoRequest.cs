using AgendaChallenger.Domain.Commands.Responses;
using MediatR;

namespace AgendaChallenger.Domain.Commands.Requests
{
    public class CreateCompromissoRequest : IRequest<CreateCompromissoResponse>
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Localizacao { get; set; }
        //public Status Status { get; set; }
    }
}