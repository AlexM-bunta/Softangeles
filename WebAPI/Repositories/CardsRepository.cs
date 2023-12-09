using Microsoft.EntityFrameworkCore;
using WebAPI.Contracts;
using WebAPI.EntityFramework.Context;
using WebAPI.Extensions;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Responses.Enums;

namespace WebAPI.Repositories;

public class CardsRepository : ICardsRepository
{
    private readonly ApplicationDbContext _context;
    
    public CardsRepository(ApplicationDbContext dbContext)
    {
        _context = dbContext;
    }
    
    public async Task<List<Card>> GetCardsByAccountId(int id)
    {
        var cardsList = await _context.Cards.Where(c => c.BankAccountId == id).ToListAsync();

        return cardsList;
    }

    public async Task<CardAddResponseCode> AddCard(Card card)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var cardAdded = await _context.Cards.AddAsync(card);

                if (cardAdded.State != EntityState.Added)
                    throw new Exception();

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                
                return CardAddResponseCode.Success;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return CardAddResponseCode.Fail;
            }
        }
    }
    
    public async Task<bool> DoesNumberExist(string number)
    {
        return await _context.Cards.AnyAsync(c => c.Number.Equals(number));
    }
}