using BankSystem.Models;
using Microsoft.EntityFrameworkCore;

public class BankingDbContext:DbContext
{
    public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
    {
    }
    public DbSet<Customer> Customer { get; set; }
}

