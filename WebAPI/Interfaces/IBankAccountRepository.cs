using WebAPI.Models;

namespace WebAPI.Interfaces;

public interface IBankAccountRepository
{
    Task<List<BankAccount>> GetBankAccountsByUser(int userId);
    Task<List<BankAccountType>> GetBankAccountTypes();
}