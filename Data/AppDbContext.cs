using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public sealed class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        private DbSet<Compromisso>? Compromissos { get; set; }
        private DbSet<Usuario>? Usuario { get; set; }
    }
}
