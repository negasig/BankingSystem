using BankSystem.Application;
using BankSystem.Domains;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Infrastructure
{
    public class CustomerRepoImpl : ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CustomerRepoImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public Task<List<Customer>> GetAllAsync()
        {
            return _context.Customer.ToListAsync();
        }

        public async Task<Customer?> GetCustomerById(string accnum)
        {
            return await _context.Customer.FirstOrDefaultAsync(a=>a.AccountNumber==accnum);
        }

        public async Task DeleteCustomer(Customer customer)
        {
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomer(Customer customer, string id)
        {
            await _context.SaveChangesAsync();  
        }

       public async Task<Customer?> GetCustomerByUsername(string uname)
        {
            return await _context.Customer.FirstOrDefaultAsync(a=>a.Username==uname);
        }
    }
}

