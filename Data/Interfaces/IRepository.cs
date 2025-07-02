using Data.Abstractions;
using System.Linq.Expressions;

namespace Data.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
