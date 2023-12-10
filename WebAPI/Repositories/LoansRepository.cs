using Microsoft.EntityFrameworkCore;
using WebAPI.Contracts;
using WebAPI.EntityFramework.Context;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Responses;
using WebAPI.Responses.Enums;

namespace WebAPI.Repositories;

public class LoansRepository : ILoansRepository
{
    private readonly ApplicationDbContext _context;

    public LoansRepository(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<GetUserLoansResponse> GetUserLoans(int userId)
    {
        var getUserLoansResponse = new GetUserLoansResponse()
        {
            UserLoansResponseCode = UserLoansResponseCode.Success
        };

        var loans = await _context.Loans.Where(l => l.UserId == userId).ToListAsync();

        if (loans == null || loans.Count == 0)
            getUserLoansResponse.UserLoansResponseCode = UserLoansResponseCode.NoObjectsFound;
        else
            getUserLoansResponse.Loans = loans;

        return getUserLoansResponse;
    }

    public async Task<UserLoansResponseCode> AddLoan(LoanAddContract loanContract)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var loan = new Loan()
                {
                    UserId = loanContract.UserId,
                    Interest = loanContract.Interest,
                    Months = loanContract.Months,
                    RequestedAmount = loanContract.RequestedAmount,
                    TotalAmount = loanContract.TotalAmount,
                    PaidAmount = 0
                };
                
                var loanAdded = await _context.Loans.AddAsync(loan);

                if (loanAdded.State != EntityState.Added)
                    throw new Exception();
                
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return UserLoansResponseCode.Success;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return UserLoansResponseCode.Fail;
            }
        }
    }

}