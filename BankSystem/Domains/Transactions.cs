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
        public Transaction(string FirstName, string LastName, string SenderAccount ,string ReceiverAccount, decimal Amount, string Reason, DateTimeOffset CreatedAt)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.SenderAccount = SenderAccount;
            this.ReceiverAccount = ReceiverAccount;
            this.Amount = Amount;
            this.Reason = Reason;
            this.CreatedAt = CreatedAt;
            
        }
    }
}
