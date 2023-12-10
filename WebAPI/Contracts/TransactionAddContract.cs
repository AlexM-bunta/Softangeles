namespace WebAPI.Contracts;

public class TransactionAddContract
{
    public decimal Amount { get; set; }
    public int DestinationAccountId { get; set; }
    public int SourceAccountId { get; set; }
    public string Details { get; set; } = string.Empty;
}