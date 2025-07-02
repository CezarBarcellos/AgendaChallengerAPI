using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using MediatR;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace AgendaChallenger.Domain.Commands.Requests.Compromisso
{
    public class GetCompromissoRequest : IRequest<GetCompromissoResponse>
    {
        public required int Id { get; set; }
    }
}