using BankSystem.Domains;

namespace BankSystem.Application
{
    public class TransferUseCases
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly ICustomerRepository _customerRepository;
        public TransferUseCases(ITransactionRepository transactionRepository, ICustomerRepository customerRepository)
        {
            _transactionRepository = transactionRepository;
            _customerRepository = customerRepository;
        }
        public async Task<bool> Transfer(Transaction transaction)
        {
            var sender = await _customerRepository.GetCustomerById(transaction.SenderAccount);
            var reciver = await _customerRepository.GetCustomerById(transaction.ReceiverAccount);
            if (sender == null || reciver == null)
                return false;
            sender.Withdraw(transaction.Amount);
            reciver.Deposit(transaction.Amount);
            var tr = new Transaction(sender.FirstName, sender.LastName, transaction.SenderAccount, transaction.ReceiverAccount, transaction.Amount, transaction.Reason, transaction.CreatedAt);
            await _transactionRepository.AddAsync(tr);
            return true;
        }
        public async Task<List<Transaction>> Transactions()
        {
            return await _transactionRepository.Transactions();
        }
    }
}
