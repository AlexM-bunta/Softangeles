using WebAPI.Models.Views;
using WebAPI.Responses;

namespace WebAPI.Interfaces;

public interface IBankAccountService
{
    Task<GetBankAccountsResponse> GetBankAccountDetailsBySessionId(Guid guid);
}