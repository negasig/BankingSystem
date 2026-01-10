namespace BankSystem.Application
{
    public record TransferRequestDto
    (
        string SenderAccount,
    string ReceiverAccount,
    decimal Amount

);
}