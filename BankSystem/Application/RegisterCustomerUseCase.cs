using BankSystem.Domains;

namespace BankSystem.Application
{

public class RegisterCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepo;

        public RegisterCustomerUseCase(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task ExecuteAsync(string? firstName, string? lastName, string? email, string? city, decimal? balance, string? username, string? password, string? AccountNumber)
        {
            var customer = new Customer(firstName, lastName, email, city, balance, username, password, AccountNumber);
            await _customerRepo.AddAsync(customer);
        }
    }
}
