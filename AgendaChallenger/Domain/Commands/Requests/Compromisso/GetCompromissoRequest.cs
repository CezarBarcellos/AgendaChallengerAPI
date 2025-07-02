using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using MediatR;

namespace AgendaChallenger.Domain.Commands.Requests.Compromisso
{
    public class GetCompromissoRequest : IRequest<GetCompromissoResponse>
    {
        public string Id { get; set; }
    }
}