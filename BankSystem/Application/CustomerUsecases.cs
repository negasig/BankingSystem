using BankSystem.Domains;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BankSystem.Application
{
    public class CustomerUsecases
    {
        private readonly ICustomerRepository _listcustomers;
        private readonly ICustomerRepository _registerRepo;
        public   CustomerUsecases(ICustomerRepository _repository, ICustomerRepository _customerRepo)
        {
            this._listcustomers = _repository;
            this._registerRepo = _customerRepo;
        }
        public async Task<List<Customer>> GetCustomers()
        {
            return await _listcustomers.GetAllAsync();
        }
        public async Task<bool> RegisterCustomer(string? firstName, string? lastName, string? email, string? city, decimal? balance, string? username, string? password, string? AccountNumber)
        {
            try
            {
                var customer = new Customer(firstName, lastName, email, city, balance, username, password, AccountNumber);

                await _registerRepo.AddAsync(customer);
                    return true;
            }
            catch
            {
                return false;
            }
          
        }
        public async Task<Customer?> GetCustomerById(string id)
        {
            return await _registerRepo.GetCustomerById(id);
        }
        public async Task<Customer?> GetCustomerByUsername(string useranme)
        {
            return await _registerRepo.GetCustomerByUsername(useranme);
        }
        public async Task DeleteCustomer(string id)
        {
            var customer = await _registerRepo.GetCustomerById(id);
            if (customer == null)
            {
                throw new ApplicationException($"Customer with Id {id} Not Found");
            }

            await _registerRepo.DeleteCustomer(customer);
           
        }
        public async Task UpdateCustomer(string id, Customer customeru)
        {
            var customer = await _registerRepo.GetCustomerById(id);
            if (customer == null)
            {
                throw new ApplicationException($"Customer with Id {id} Not Found");
            }

            customer.FirstName = customeru.FirstName;
            customer.LastName = customeru.LastName;
            customer.Email = customeru.Email;
            customer.Balance = customeru.Balance;
            customer.City = customeru.City;
            await _registerRepo.UpdateCustomer(customer, id);

        }

    }
}

