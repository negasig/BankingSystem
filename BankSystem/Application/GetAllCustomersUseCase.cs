using BankSystem.Domains;

namespace BankSystem.Application
{
    public class GetAllCustomersUseCase
    {
        private readonly ICustomerRepository _customerRepo;

        public GetAllCustomersUseCase(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<List<Customer>> ExecuteAsync()
        {
            return await _customerRepo.GetAllAsync();
        }
    }
}