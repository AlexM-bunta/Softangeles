namespace WebAPI.Contracts;

public class TransactionContract
{
    public string DestinationIBAN { get; set; } = string.Empty;
    public string SourceIBAN { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Details { get; set; }
}