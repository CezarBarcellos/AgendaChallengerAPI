﻿using AgendaChallenger.Domain.Commands.Responses.Compromisso;
using AgendaChallenger.Entities;
using MediatR;

namespace AgendaChallenger.Domain.Commands.Requests.Compromisso
{
    public class UpdateCompromissoRequest : IRequest<UpdateCompromissoResponse>
    {
        public required string Id { get; set; }
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public string? Localizacao { get; set; }
        public Status? Status { get; set; }
    }
}