using Data.Abstractions;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly AppDbContext _dbContext;
        public UsuarioRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Usuario>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Usuario>().ToListAsync(cancellationToken);
        }
    }
}
