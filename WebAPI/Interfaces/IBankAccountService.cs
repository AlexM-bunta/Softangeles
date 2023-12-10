using WebAPI.Contracts;
using WebAPI.Models.Views;
using WebAPI.Responses;
using WebAPI.Responses.Enums;

namespace WebAPI.Interfaces;

public interface IBankAccountService
{
    Task<GetBankAccountsResponse> GetBankAccountDetailsBySessionId(Guid guid);
    Task<AccountAddResponseCode> AddAccount(AccountAddContract accountContract);
    Task<UserLoansResponseCode> AddBalance(AccountAddBalanceContract accountContract);
}