﻿using AgendaChallenger.Domain.Commands.Responses.Usuario;
using MediatR;

namespace AgendaChallenger.Domain.Commands.Requests.Usuario
{
    public class GetUsuarioRequest : IRequest<GetUsuarioResponse>
    {
        public required int Id { get; set; }
    }
}