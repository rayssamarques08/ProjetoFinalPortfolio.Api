using Microsoft.EntityFrameworkCore;

namespace ProjetoFinalPortfolio.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<>  { get; set; }
        public DbSet<>  { get; set; }
        public DbSet<>  { get; set; }
        public DbSet<>  { get; set; }
    }
}
