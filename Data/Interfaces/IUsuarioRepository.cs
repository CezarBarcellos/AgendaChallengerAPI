using Data.Abstractions;
using Data.Models;

namespace Data.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Add(Usuario usuario);

        Task<Usuario> Update(Usuario usuario);

        Task<int> Delete(Usuario usuario);

        Task<List<Usuario>> GetAll(CancellationToken cancellationToken = default);
        Task<Usuario?> Get(int id, CancellationToken cancellationToken = default);
        Task<Usuario?> GetByToken(string nome, string senha, CancellationToken cancellationToken = default);
    }
}
