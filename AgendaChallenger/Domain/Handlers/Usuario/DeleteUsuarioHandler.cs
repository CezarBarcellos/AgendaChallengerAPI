using AgendaChallenger.Domain.Commands.Requests.Usuario;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using AutoMapper;
using Data.Abstractions;
using Data.Interfaces;
using MediatR;

namespace AgendaChallenger.Domain.Handlers.Usuario
{
    public class DeleteUsuarioHandler : IRequestHandler<DeleteUsuarioRequest, DeleteUsuarioResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public DeleteUsuarioHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, IMapper mapper, ISender sender)
        {
            _usuarioRepository = usuarioRepository;
            _sender = sender;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public Task<DeleteUsuarioResponse> Handle(DeleteUsuarioRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteUsuarioResponse();
            // var usuario = await _usuarioRepository.GetByIdAsync(request.Id, cancellationToken);
            if (usuario == null)
            {
                result.Success = false;
            }
            else
            {
                _usuarioRepository.Delete(usuario);
                int Ok = _unitOfWork.SaveChangesAsync(cancellationToken).Result;
                if (Ok > 0)
                {
                    result.Success = true;
                }
            }

            return Task.FromResult(result);
        }
    }
}
