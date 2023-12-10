using WebAPI.Contracts;
using WebAPI.Interfaces;
using WebAPI.Responses;
using WebAPI.Responses.Enums;

namespace WebAPI.Services;

public class TransactionsService : ITransactionsService
{
    private readonly ITransactionsRepository _transactionRepository;
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly ISessionsRepository _sessionsRepository;

    public TransactionsService(
        ITransactionsRepository transactionRepo, 
        ISessionsRepository sessionsRepo, 
        IBankAccountRepository bankAccountRepo)
    {
        _transactionRepository = transactionRepo;
        _sessionsRepository = sessionsRepo;
        _bankAccountRepository = bankAccountRepo;
    }
    
    public async Task<TransactionProcessResponseCode> ProcessTransaction(TransactionContract transactionContract)
    {
        // Search for source and verify balance
        var sourceAccount = await _bankAccountRepository.GetBankAccountByIBAN(transactionContract.SourceIBAN);

        if (sourceAccount == null)
            return TransactionProcessResponseCode.SourceAccountNotFound;
        
        if (sourceAccount.Balance - transactionContract.Amount < 0)
            return TransactionProcessResponseCode.NotEnoughBalance;

        // Search for destination
        var destinationAccount = await _bankAccountRepository.GetBankAccountByIBAN(transactionContract.DestinationIBAN);

        if (destinationAccount == null)
            return TransactionProcessResponseCode.DestinationAccountNotFound;
        
        // Add transaction
        var transactionAddContract = new TransactionAddContract()
        {
            Amount = transactionContract.Amount,
            Details = transactionContract.Details,
            DestinationAccountId = destinationAccount.Id,
            SourceAccountId = sourceAccount.Id
        };
        
        var responseCode = await _transactionRepository.AddTransaction(transactionAddContract);

        if (responseCode == BaseResponseCode.Fail)
            return TransactionProcessResponseCode.Fail;
        
        return TransactionProcessResponseCode.Successful;
    }

    public async Task<TransactionsGetResponse> GetTransactions(Guid sessionId)
    {
        var userId = await _sessionsRepository.GetActiveUserIdBySession(sessionId);

        var accounts = await _bankAccountRepository.GetBankAccountsByUser(userId);

        var response = await _transactionRepository.GetTransactions(accounts);

        return response;
    }
}