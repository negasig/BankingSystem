namespace BankSystem.Models
{
    public class Customer
    {
        public int id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Email { get; set; }

        public string? City { get; set; }

        public decimal? Balance { get; set; }
    }
}
