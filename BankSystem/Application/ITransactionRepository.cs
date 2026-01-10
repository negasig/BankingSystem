using BankSystem.Domains;

namespace BankSystem.Application
{
    public interface ITransactionRepository
    {
        Task AddAsync(Transaction transaction);
        Task<List<Transaction>> Transactions();
    }
}
