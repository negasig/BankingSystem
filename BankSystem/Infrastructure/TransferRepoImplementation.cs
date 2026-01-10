using BankSystem.Application;
using BankSystem.Domains;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infrastructure
{
    public class TransferRepoImplementation : ITransactionRepository
    {
        AppDbContext appDbContext;
        public TransferRepoImplementation(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public Task AddAsync(Transaction transaction)
        {
            appDbContext.Transactions.AddAsync(transaction);
            return appDbContext.SaveChangesAsync();
        }

        public async Task<List<Transaction>> Transactions()
        {
           return await appDbContext.Transactions.ToListAsync();
        }
    }
}
