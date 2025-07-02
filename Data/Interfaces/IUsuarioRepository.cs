using Data.Abstractions;
using Data.Models;

namespace Data.Interfaces
{
    public interface IUsuarioRepository
    {
        void Add(Usuario compromisso);

        void Update(Usuario compromisso);

        void Delete(Usuario compromisso);
    }
}
