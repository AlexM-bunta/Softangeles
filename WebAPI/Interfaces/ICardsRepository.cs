using WebAPI.Models;

namespace WebAPI.Interfaces;

public interface ICardsRepository
{
    Task<List<Card>> GetCardsByAccountId(int id);
}