using BankSystem.Domains;
using Microsoft.AspNetCore.Mvc;

namespace BankSystem.Application
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<List<Customer>> GetAllAsync();
        Task<Customer?> GetCustomerById(string accnum);
        Task<Customer?> GetCustomerByUsername(string uname);
        Task DeleteCustomer(Customer customer);
        Task UpdateCustomer(Customer customer, string accnumber);
        
     }
}
