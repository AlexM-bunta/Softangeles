namespace WebAPI.Models.Views;

public class BankAccountDetails
{
    public int Id { get; set; }
    public string Type { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public string IBAN { get; set; } = string.Empty;
}