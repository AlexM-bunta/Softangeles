using WebAPI.Responses.Enums;

namespace WebAPI.Responses;

public class GetAccountBalanceResponse
{
    public BaseResponseCode AccountResponseCode { get; set; }
    public decimal Balance { get; set; }
}