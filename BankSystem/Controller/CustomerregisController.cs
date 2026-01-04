using BankSystem.Application;
using BankSystem.Domains;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Controller
{
    [ApiController]
    [Route("api/")]
  
    public class CustomerController : ControllerBase
    {
        private readonly RegisterCustomerUseCase _registerUseCase;
        private readonly GetAllCustomersUseCase _getAllUseCase;

        public CustomerController(
            RegisterCustomerUseCase registerUseCase,
            GetAllCustomersUseCase getAllUseCase)
        {
            _registerUseCase = registerUseCase;
            _getAllUseCase = getAllUseCase;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Customer request)
        {
            await _registerUseCase.ExecuteAsync(
request.FirstName, request.LastName, request.Email, request.City, request.Balance,request.Username, request.Password, request.AccountNumber);

            return Ok("Customer registered");
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _getAllUseCase.ExecuteAsync();
            return Ok(customers);
        }
    }
}
