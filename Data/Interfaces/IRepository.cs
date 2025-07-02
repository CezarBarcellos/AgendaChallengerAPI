using Data.Abstractions;

namespace Data.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task<int> Delete(T entity);
    }
}
