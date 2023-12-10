using WebAPI.Responses.Enums;

namespace WebAPI.Responses;

public class GetAccountBalanceResponse
{
    public AccountResponseCode AccountResponseCode { get; set; }
    public decimal Balance { get; set; }
}