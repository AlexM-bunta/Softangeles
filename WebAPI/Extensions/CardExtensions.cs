using WebAPI.Contracts;
using WebAPI.Models;

namespace WebAPI.Extensions;

public static class CardExtensions
{
    public static Card ToCard(CardAddContract cardContract)
    {
        return new Card()
        {
            BankAccountId = cardContract.AccountId,
            Number = cardContract.Number,
            CVV = cardContract.CVV,
            IsPhysical = cardContract.IsPhysical,
            CreateDate = DateTimeExtensions.SetKindUtc(DateTime.Now) ?? DateTime.Now,
            ExpiryDate = DateTimeExtensions.SetKindUtc(DateTime.Now.AddMonths(cardContract.Months)) ?? DateTime.Now,
        };
    }
}