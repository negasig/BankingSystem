using BankSystem.Domains;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infrastructure
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.ApplyConfigurationsFromAssembly(
                    typeof(AppDbContext).Assembly);
                base.OnModelCreating(modelBuilder);
            }
        }

}

