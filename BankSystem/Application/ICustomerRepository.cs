using BankSystem.Domains;

namespace BankSystem.Application
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<List<Customer>> GetAllAsync();
    }
}
