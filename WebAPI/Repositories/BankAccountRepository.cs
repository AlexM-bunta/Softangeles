using Microsoft.EntityFrameworkCore;
using WebAPI.EntityFramework.Context;
using WebAPI.Interfaces;
using WebAPI.Models;

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
}