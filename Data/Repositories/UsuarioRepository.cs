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

        public async Task<List<Usuario>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Usuario>().ToListAsync(cancellationToken);
        }

        public async Task<Usuario?> Get(int id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Usuario>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public async Task<Usuario?> GetByToken(string nome, string senha, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Usuario>().FirstOrDefaultAsync(x => x.Nome == nome && x.Senha == senha, cancellationToken);
        }
    }
}
