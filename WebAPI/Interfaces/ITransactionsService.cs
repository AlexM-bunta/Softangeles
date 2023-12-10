using WebAPI.Contracts;
using WebAPI.Responses;
using WebAPI.Responses.Enums;

namespace WebAPI.Interfaces;

public interface ITransactionsService
{
    Task<TransactionProcessResponseCode> ProcessTransaction(TransactionContract transactionContract);
    Task<TransactionsGetResponse> GetTransactions(Guid sessionId);

}