using WebAPI.Models;
using WebAPI.Responses;
using WebAPI.Responses.Enums;

namespace WebAPI.Interfaces;

public interface IBankAccountRepository
{
    Task<List<BankAccount>> GetBankAccountsByUser(int userId);
    Task<List<BankAccountType>> GetBankAccountTypes();
    Task<AccountAddResponseCode> AddAccount(BankAccount bankAccount);
    Task<GetAccountBalanceResponse> GetCurrentBalance(int accountId);
}