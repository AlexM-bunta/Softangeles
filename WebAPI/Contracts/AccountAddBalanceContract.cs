namespace WebAPI.Contracts;

public class AccountAddBalanceContract
{
    public Guid SessionId { get; set; }
    public decimal Amount { get; set; }
    public string IBAN { get; set; }
}