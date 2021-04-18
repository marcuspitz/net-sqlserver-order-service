using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SimpleOrder.Infra.Data.Models;

namespace SimpleOrder.Infra.Data
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public static readonly string MIGRATIONS_HISTORY_TABLE = "_EFMigrationHistory";
        public DbSet<Product> Product { get; set; }


        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public class GlobalContextDesignFactory : IDesignTimeDbContextFactory<DatabaseContext>
        {
            public DatabaseContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=simpleorder;Trusted_Connection=True;");

                return new DatabaseContext(optionsBuilder.Options);
            }
        }

    }
}
