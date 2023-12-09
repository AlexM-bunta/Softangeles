
using WebAPI.Models;
using WebAPI.Models.Views;

namespace WebAPI.Extensions;

public static class BankAccountExtensions
{
    public static BankAccountDetails ToView(BankAccount bank, string type)
    {
        return new BankAccountDetails()
        {
            Id = bank.Id,
            Type = type,
            Balance = bank.Balance,
            IBAN = bank.IBAN
        };
    }
}