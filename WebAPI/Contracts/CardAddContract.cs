namespace WebAPI.Contracts;

public class CardAddContract
{
    public int AccountId { get; set; }
    public bool IsPhysical { get; set; }
    public int Months { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Number { get; set; } = string.Empty;
    public string CVV { get; set; } = string.Empty;
}