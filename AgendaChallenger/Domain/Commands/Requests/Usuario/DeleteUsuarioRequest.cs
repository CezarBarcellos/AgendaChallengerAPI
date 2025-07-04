﻿using AgendaChallenger.Domain.Commands.Responses.Usuario;
using MediatR;

namespace AgendaChallenger.Domain.Commands.Requests.Usuario
{
    public class DeleteUsuarioRequest : IRequest<DeleteUsuarioResponse>
    {
        public required int Id { get; set; }
    }
}