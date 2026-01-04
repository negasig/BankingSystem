
using BankSystem.Domains;
using BankSystem.Infrastructure;
using BankSystem.NewFolder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Server;
using System.Diagnostics;
namespace BankSystem.controllers
{

    [ApiController]
    [Route("api/")]



    public class CustomerController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CustomerController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("list")]
        public async Task<ActionResult> GetCustomers()
        {
            var customers = await _context.Customer.AsNoTracking().ToListAsync();
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
            _context.SaveChanges();
            return Ok("Customer with ID " + id + "has been deleted");
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
        
            _context.SaveChanges();
            return Ok(existingCustomer);
        }
        [HttpPost("login")]
        public Task<IActionResult> Login(LoginDto login)
        {
            var customer = _context.Customer.FirstOrDefault(c => c.Username == login.Username && c.Password == login.Password);
            if (customer == null)
            {
                return Task.FromResult<IActionResult>(Unauthorized("Invalid email or password"));
            }
            return Task.FromResult<IActionResult>(Ok("Loged in Successfully"));
        }
        [HttpPost("transfer")]
        public Task<IActionResult> Transfer(Transaction tr)
        {
            var sender = _context.Customer.FirstOrDefault(c => c.AccountNumber == tr.SenderAccount);
            var receiver = _context.Customer.FirstOrDefault(c => c.AccountNumber == tr.ReceiverAccount);

            if (sender != null && receiver != null && sender.Balance > tr.Amount)
            {
          
                _context.SaveChanges();

                _context.Transactions.Add(new Transaction
                {
                    FirstName = sender.FirstName,
                    LastName = sender.LastName,
                    Amount = tr.Amount,
                    SenderAccount = tr.SenderAccount,
                    ReceiverAccount = tr.ReceiverAccount,
                    Reason = tr.Reason
                });
                _context.SaveChanges();
            }

            else if (sender != null && sender.Balance < tr.Amount)
            {
                return Task.FromResult<IActionResult>(BadRequest("Sender has insufficient balance"));
            }
            else if (sender == null)
            {
                return Task.FromResult<IActionResult>(BadRequest(tr.SenderAccount + " is not valid account"));
            }
            else if (receiver == null)
            {
                return Task.FromResult<IActionResult>(BadRequest(tr.ReceiverAccount + " is not valid account"));
            }


            return Task.FromResult<IActionResult>(Ok("trsnaferd"));
        }
        [HttpGet("transactions")]
        public async Task<IActionResult> geTransactions()
        {
            var transactions = await _context.Transactions.ToListAsync();
            return Ok(transactions);
        }
    }
}