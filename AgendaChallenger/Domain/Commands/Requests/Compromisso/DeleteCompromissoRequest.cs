using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using MediatR;

namespace AgendaChallenger.Domain.Commands.Requests.Compromisso
{
    public class DeleteCompromissoRequest : IRequest<DeleteCompromissoResponse>
    {
        public string Id { get; set; }
    }
}