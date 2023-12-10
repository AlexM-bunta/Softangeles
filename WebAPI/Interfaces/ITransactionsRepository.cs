using WebAPI.Contracts;
using WebAPI.Models;
using WebAPI.Responses;
using WebAPI.Responses.Enums;

namespace WebAPI.Interfaces;

public interface ITransactionsRepository
{
    Task<BaseResponseCode> AddTransaction(TransactionAddContract transactionContract);
    Task<TransactionsGetResponse> GetTransactions(List<BankAccount> accounts);
}