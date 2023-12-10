using Microsoft.EntityFrameworkCore;
using WebAPI.Contracts;
using WebAPI.EntityFramework.Context;
using WebAPI.Extensions;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Responses.Enums;

namespace WebAPI.Repositories;

public class TransactionsRepository : ITransactionsRepository
{
    private readonly ApplicationDbContext _context;
    
    public TransactionsRepository(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }
    
    public async Task<BaseResponseCode> AddTransaction(TransactionAddContract transactionContract)
    {
        using (var dbContextTransaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var transaction = new Transaction()
                {
                    Amount = transactionContract.Amount,
                    CreateDate = DateTimeExtensions.SetKindUtc(DateTime.Now) ?? DateTime.Now,
                    DestinationAccountId = transactionContract.DestinationAccountId,
                    SourceAccountId = transactionContract.SourceAccountId,
                    Details = transactionContract.Details
                };

                var transactionAdded = await _context.Transactions.AddAsync(transaction);

                if (transactionAdded.State != EntityState.Added)
                    throw new Exception();

                await _context.SaveChangesAsync();
                await dbContextTransaction.CommitAsync();

                return BaseResponseCode.Successful;
            }
            catch (Exception)
            {
                await dbContextTransaction.RollbackAsync();
                return BaseResponseCode.Fail;
            }
        }
    }
}