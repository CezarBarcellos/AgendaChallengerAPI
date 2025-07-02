using Data.Models;

namespace AgendaChallenger.Domain.Interfaces
{
    public interface ITokenProvider
    {
        string Create(Usuario usuario);
    }
}
