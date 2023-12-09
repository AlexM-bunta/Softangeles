namespace WebAPI.Contracts;

public class UserRegisterContract : UserBaseContract
{
    public string Email { get; set; } = string.Empty;
}