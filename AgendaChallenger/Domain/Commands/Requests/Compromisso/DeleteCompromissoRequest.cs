﻿using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using MediatR;

namespace AgendaChallenger.Domain.Commands.Requests.Compromisso
{
    public class DeleteCompromissoRequest : IRequest<DeleteCompromissoResponse>
    {
        public required string Id { get; set; }
    }
}