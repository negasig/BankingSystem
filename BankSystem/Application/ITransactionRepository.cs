using BankSystem.Domains;

namespace BankSystem.Application
{
    public interface ITransactionRepository
    {
        Task<Transaction> GetByIdAsync(string accountnumber);
        Task AddAsync(Transaction transaction);
        Task Transfer(Transaction transaction);
    }
}
