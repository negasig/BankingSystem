
using BankSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace BankSystem.controllers
{

    [ApiController]
    [Route("api/[controller]")]



    public class CustomerController : ControllerBase
    {
        private readonly BankingDbContext _context;
        public CustomerController(BankingDbContext context)
        {
            _context = context;
        }
        [HttpGet("list")]
        public async Task<ActionResult> GetCustomers()
        {
            var customers = await _context.Customer.ToListAsync();
            return Ok(customers);
        }

        [HttpPost("addcustomer")]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return Ok(customer);
        }
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Customer>> getCustomerById(int id)
        {
            var customer = _context.Customer.Find(id);
            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found");
            }
            return Ok(customer);
        }
        [HttpDelete("deletcus/{id}")]
        public ActionResult deleteCustomer(int id)
        {
            var cus = _context.Customer.Find(id);
            if (cus == null)
            {
                return NotFound($"Customer with ID {id} not found");
            }
            _context.Customer.Remove(cus);
            _context.SaveChangesAsync();
            return Ok($"Customer with ID {id} has been deleted");
        }
        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, Customer updatedCustomer)
        {
            var existingCustomer = _context.Customer.Find(id);
            if (existingCustomer == null)
            {
                return NotFound($"Customer with ID {id} Not found");
            }
            existingCustomer.FirstName = updatedCustomer.FirstName;
            existingCustomer.LastName = updatedCustomer.LastName;
            existingCustomer.Email = updatedCustomer.Email;
            existingCustomer.City = updatedCustomer.City;
            existingCustomer.Balance = updatedCustomer.Balance;
            _context.SaveChanges();
            return Ok(existingCustomer);
        }
        [HttpPost("login")]
        public ActionResult<Customer> Login()
        {

            return Ok("Negasi Gide");
        }
    }
}