using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SimpleOrder.Infra.Data.Models;

namespace SimpleOrder.Infra.Data
{
    public class DatabaseContext : IdentityDbContext
    {
        public static readonly string MIGRATIONS_HISTORY_TABLE = "_EFMigrationHistory";
        public DbSet<Product> Product { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}
