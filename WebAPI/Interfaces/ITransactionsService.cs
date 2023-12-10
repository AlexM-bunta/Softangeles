using WebAPI.Contracts;
using WebAPI.Responses.Enums;

namespace WebAPI.Interfaces;

public interface ITransactionsService
{
    Task<TransactionProcessResponseCode> ProcessTransaction(TransactionContract transactionContract);
}