using IntelliStocks.Models;
using Microsoft.EntityFrameworkCore;

namespace IntelliStocks.Persistence
{
    public class OracleDbContext : DbContext
    {
        public DbSet<Produto> Produto { get; set; }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Usuario> Usuario { get; set; }

        public OracleDbContext(DbContextOptions<OracleDbContext> options) : base(options) { }

    }
}
