using BankSystem.Application;
using BankSystem.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

namespace BankSystem.Controller
{
    [ApiController]
    [Route("api/")]

    public class CustomerController : ControllerBase
    {
        private readonly CustomerUsecases _custservices;
        private readonly TransferUseCases _transferservices;

        public CustomerController(
            CustomerUsecases usecase, TransferUseCases transferservices)
        {
            _custservices = usecase;
            _transferservices = transferservices;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Customer request)
        {
           var res= await _custservices.RegisterCustomer(
request.FirstName, request.LastName, request.Email, request.City, request.Balance, request.Username, request.Password, request.AccountNumber);
          
            return Ok(res);
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _custservices.GetCustomers();
            return Ok(customers);
        }
        [HttpGet("customers/{id}")]
        public async Task<ActionResult> GetCustomerById(string id)
        {
            var customer = await _custservices.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound($"No Customer with Id {id}");
            }
            return Ok(customer);
        }
        [HttpDelete("deletecus/{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            try
            {
                await _custservices.DeleteCustomer(id);
                return Ok($"Customer with Id {id} has been Deleted"); // 204
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPut("updateCustomer/{id}")]
        public async Task<IActionResult> UpdateCustomer(string id, Customer c)
        {
            try
            {
                await _custservices.UpdateCustomer(id, c);
                return Ok($"Customer with Id {id} has been Updated"); // 204
            }
            catch (ApplicationException ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost("transfer")]
        public async Task<IActionResult> Transfer(Transaction transaction)
        {
            var result=await _transferservices.Transfer(transaction);
            if(result==false)
            {
                return BadRequest("Sender or Receiver Account Not found");
            }
            return Ok("Transfer successfull");
        }
        [HttpGet("transactions")]
        public  async Task<List<Transaction>> transactions()
        {
          return await _transferservices.Transactions();
        }
    }
}

