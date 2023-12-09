using System.Data.Entity;
using WebAPI.EntityFramework.Context;
using WebAPI.Interfaces;
using WebAPI.Models;

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
}