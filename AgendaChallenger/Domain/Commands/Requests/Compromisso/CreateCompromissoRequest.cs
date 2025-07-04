using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using Data.Models;
using MediatR;

namespace AgendaChallenger.Domain.Commands.Requests.Compromisso
{
    public class CreateCompromissoRequest : IRequest<CreateCompromissoResponse>
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public string Localizacao { get; set; }
        public int Status { get; set; }
    }
}