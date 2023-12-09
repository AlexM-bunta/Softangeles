using WebAPI.Contracts;
using WebAPI.Models;
using WebAPI.Responses.Enums;

namespace WebAPI.Interfaces;

public interface ICardsRepository
{
    Task<List<Card>> GetCardsByAccountId(int id);
    Task<CardAddResponseCode> AddCard(Card card);
    Task<bool> DoesNumberExist(string number);
}