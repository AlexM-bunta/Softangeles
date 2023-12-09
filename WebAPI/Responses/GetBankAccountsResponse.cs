using WebAPI.Models.Views;
using WebAPI.Responses.Enums;

namespace WebAPI.Responses;

public class GetBankAccountsResponse
{
    public List<BankAccountDetails> BankAccountDetailsList { get; set; }
    public BankAccountResponseCode BankAccountResponseCode { get; set; }
}