using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using MediatR;

namespace AgendaChallenger.Domain.Commands.Requests.Compromisso
{
    public class GetAllCompromissoRequest : IRequest<GetAllCompromissoResponse>
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
    }
}