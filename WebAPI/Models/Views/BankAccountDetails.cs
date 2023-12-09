namespace WebAPI.Models.Views;

public class BankAccountDetails
{
    public int Id { get; set; }
    
    public string Type { get; set; } = string.Empty;
    
    public double Balance { get; set; }

    public string IBAN { get; set; } = string.Empty;
}