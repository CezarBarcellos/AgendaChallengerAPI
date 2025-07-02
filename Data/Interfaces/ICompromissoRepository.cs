using Data.Models;

namespace Data.Interfaces
{
    public interface ICompromissoRepository
    {
        void Add(Compromisso compromisso);

        void Update(Compromisso compromisso);

        void Delete(Compromisso compromisso);
    }
}
