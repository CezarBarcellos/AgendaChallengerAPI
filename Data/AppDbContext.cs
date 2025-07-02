//using Data.Abstractions;
//using Data.Models;
//using Microsoft.EntityFrameworkCore;
//using System.Data;
//using System.Resources;

//namespace Data
//{
//    public sealed class AppDbContext(DbContextOptions options) : DbContext(options)
//    {
//        private DbSet<Compromisso>? Compromissos { get; set; }
//        private DbSet<Usuario>? Usuario { get; set; }

//        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
//        {
//            try
//            {
//                var result = await base.SaveChangesAsync(cancellationToken);
//                return result;
//            }
//            catch { }

//            return 0;
//        }
//    }
//}

using Microsoft.EntityFrameworkCore;
using Data.Models;

namespace Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Usuario>? Usuarios { get; set; }
        private DbSet<Compromisso>? Compromissos { get; set; }
    }
}
