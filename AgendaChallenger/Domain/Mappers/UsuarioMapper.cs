using AgendaChallenger.Domain.Commands.Create;
using AutoMapper;

namespace AgendaChallenger.Domain.Mappers
{
    public sealed class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<CreateUsuarioCommand, Data.Models.Usuario>()
                .ForMember(entity => entity.Nome, opt => opt.Ignore())
                .ForMember(entity => entity.Senha, opt => opt.Ignore());
        }
    }
}
