using WebAPI.Contracts;
using WebAPI.Models;
using WebAPI.Responses;
using WebAPI.Responses.Enums;

namespace WebAPI.Interfaces;

public interface ICardsService
{
    Task<GetCardsResponse> GetCardsByAccountId(int id);
    Task<CardAddResponseCode> AddCard(CardAddContract cardContract);
}