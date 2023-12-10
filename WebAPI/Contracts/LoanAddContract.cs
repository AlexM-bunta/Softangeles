namespace WebAPI.Contracts;

public class LoanAddContract
{
    public int UserId { get; set; }
    public decimal RequestedAmount { get; set; }
    public decimal TotalAmount { get; set; }
    public int Months { get; set; }
    public float Interest { get; set; }
}