using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.Abstractions
{
    public abstract class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly AppDbContext DbContext;

        protected Repository(AppDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public virtual async Task<T> Add(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            DbContext.Add(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<T> Update(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            DbContext.Update(entity);
            await DbContext.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<int> Delete(T entity)
        {
            ArgumentNullException.ThrowIfNull(entity);
            DbContext.Remove(entity);
            int result = await DbContext.SaveChangesAsync();
            return result;
        }
    }
}
