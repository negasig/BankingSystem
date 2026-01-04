using System.ComponentModel.DataAnnotations.Schema;

namespace BankSystem.Domains
{
    public class Transaction
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? SenderAccount { get; set; }
        public string? ReceiverAccount { get; set; }
        public decimal Amount { get; set; }
        public string Reason { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
