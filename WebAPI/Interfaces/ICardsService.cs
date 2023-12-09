using WebAPI.Models;
using WebAPI.Responses;

namespace WebAPI.Interfaces;

public interface ICardsService
{
    Task<GetCardsResponse> GetCardsByAccountId(int id);
}