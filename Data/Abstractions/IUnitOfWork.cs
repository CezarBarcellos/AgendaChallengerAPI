﻿using Microsoft.EntityFrameworkCore;

namespace Data.Abstractions
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();        
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback() { }
    }
}
