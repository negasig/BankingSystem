using BankSystem.Domains;
using BankSystem.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Application
{
    public class CutomerRepository: ICustomerRepository
    {
        private readonly AppDbContext _context;
        public CutomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer customer)
        {
            await _context.Customer.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        Task<List<Customer>> ICustomerRepository.GetAllAsync()
        {
            return _context.Customer.ToListAsync();
        }
    }
}
