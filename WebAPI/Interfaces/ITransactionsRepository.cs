using WebAPI.Contracts;
using WebAPI.Responses.Enums;

namespace WebAPI.Interfaces;

public interface ITransactionsRepository
{
    Task<BaseResponseCode> AddTransaction(TransactionAddContract transactionContract);
}