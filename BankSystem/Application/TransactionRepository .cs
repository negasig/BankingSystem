using BankSystem.Domains;
using BankSystem.Infrastructure;

namespace BankSystem.Application
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;
        private readonly CutomerRepository cutomerRepository;

        public TransactionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Transaction?> GetByIdAsync(string accountnumber)
        {
            return await _context.Transactions.FindAsync(accountnumber);
        }

        public async Task AddAsync(Transaction transaction)
        {

            await _context.Transactions.AddAsync(transaction);
            await _context.SaveChangesAsync();
        }
        public async Task Transfer(string senderacc, string recevacc, decimal amount)
        {
            
        }

        public Task Transfer(Transaction transaction)
        {
            throw new NotImplementedException();
        }
    }

}