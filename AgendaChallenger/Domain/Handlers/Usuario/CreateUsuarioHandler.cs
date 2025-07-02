using AgendaChallenger.Domain.Commands.Requests.Usuario;
using AgendaChallenger.Domain.Commands.Responses.Usuario;
using AutoMapper;
using Data.Abstractions;
using Data.Interfaces;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace AgendaChallenger.Domain.Handlers
{
    public class CreateUsuarioHandler : IRequestHandler<CreateUsuarioRequest, CreateUsuarioResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISender _sender;

        public CreateUsuarioHandler(IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, IMapper mapper, ISender sender)
        {
            _usuarioRepository = usuarioRepository;            
            _sender = sender;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public Task<CreateUsuarioResponse> Handle(CreateUsuarioRequest request, CancellationToken cancellationToken)
        {
            var usuario = _mapper.Map<Data.Models.Usuario>(request);
            _usuarioRepository.Add(usuario);            
            _unitOfWork.SaveChangesAsync(cancellationToken);
            var result = new CreateUsuarioResponse();

            return Task.FromResult(result);
        }

        public string CalculateMD5Hash(string input)
        {
            // Calcular o Hash
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // Converter byte array para string hexadecimal
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
