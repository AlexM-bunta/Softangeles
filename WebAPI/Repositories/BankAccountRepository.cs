using Microsoft.EntityFrameworkCore;
using WebAPI.EntityFramework.Context;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Responses.Enums;

namespace WebAPI.Repositories;

public class BankAccountRepository : IBankAccountRepository
{
    private readonly ApplicationDbContext _context;
    
    public BankAccountRepository(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }
    
    public async Task<List<BankAccount>> GetBankAccountsByUser(int userId)
    {
        var bankAccounts = await _context.BankAccounts.Where(b => b.UserId == userId).ToListAsync();

        return bankAccounts;
    }

    public async Task<List<BankAccountType>> GetBankAccountTypes()
    {
        var bankAccountTypes = await _context.BankAccountTypes.ToListAsync();

        return bankAccountTypes;
    }

    public async Task<AccountAddResponseCode> AddAccount(BankAccount bankAccount)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var accountAdded = await _context.BankAccounts.AddAsync(bankAccount);

                if (accountAdded.State != EntityState.Added)
                    throw new Exception();

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                
                return AccountAddResponseCode.Success;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return AccountAddResponseCode.Fail;
            }
        }
    }
}