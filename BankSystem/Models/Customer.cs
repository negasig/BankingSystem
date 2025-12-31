using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? City { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Balance { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? AccountNumber { get; set; }
    }
}
