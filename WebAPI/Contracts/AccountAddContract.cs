namespace WebAPI.Contracts;

public class AccountAddContract
{
    public string Type { get; set; } = string.Empty;
    public int UserId { get; set; }
}