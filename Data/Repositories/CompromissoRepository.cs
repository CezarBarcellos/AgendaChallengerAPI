using Data.Abstractions;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class CompromissoRepository : Repository<Compromisso>, ICompromissoRepository
    {
        private readonly AppDbContext _dbContext;
        public CompromissoRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Compromisso>> GetAll(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Compromisso>().ToListAsync(cancellationToken);
        }

        public async Task<Compromisso?> Get(string id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<Compromisso>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
