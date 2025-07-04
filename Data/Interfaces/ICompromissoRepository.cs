using Data.Models;

namespace Data.Interfaces
{
    public interface ICompromissoRepository
    {
        Task<Compromisso> Add(Compromisso compromisso);

        Task<Compromisso> Update(Compromisso compromisso);

        Task<int> Delete(Compromisso compromisso);

        Task<List<Compromisso>> GetAll(CancellationToken cancellationToken = default);
        Task<Compromisso?> Get(string id, CancellationToken cancellationToken = default);
    }
}
