using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Domains
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        public decimal? Balance { get;  set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? AccountNumber { get; set; }


        private Customer() { } // EF

        public Customer(string? firstName, string? lastName, string? email, string? city, decimal? balance, string? username, string? password, string? accountNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            City = city;
            Balance = balance;
            Username = username;
            Password = password;
            AccountNumber = accountNumber;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0) {
                throw new NotImplementedException("amount should be greater");
            }
  
            this.Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            if (amount > this.Balance)
            {
                throw new NotImplementedException("amount should be greater");
            }
            this.Balance += amount;
        }
    }
}
