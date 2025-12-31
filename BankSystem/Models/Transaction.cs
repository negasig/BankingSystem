using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SenderAccount { get; set; }
        public string? ReceiverAccount { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        public string Reason { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

}
