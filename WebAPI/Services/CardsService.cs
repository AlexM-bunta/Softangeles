using WebAPI.Contracts;
using WebAPI.Extensions;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Responses;
using WebAPI.Responses.Enums;

namespace WebAPI.Services;

public class CardsService : ICardsService
{
    private readonly ICardsRepository _cardsRepository;

    public CardsService(ICardsRepository cardsRepo)
    {
        _cardsRepository = cardsRepo;
    }

    public async Task<GetCardsResponse> GetCardsByAccountId(int id)
    {
        var getCardsResponse = new GetCardsResponse()
        {
            AccountResponseCode = BaseResponseCode.Success
        };
        
        var cardsList = await _cardsRepository.GetCardsByAccountId(id);

        if (cardsList == null || cardsList.Count == 0)
            getCardsResponse.AccountResponseCode = BaseResponseCode.NoObjectsFound;
        else
            getCardsResponse.CardsList = cardsList;
        
        return getCardsResponse;
    }

    public async Task<CardAddResponseCode> AddCard(CardAddContract cardContract)
    {
        var doesNumberExist = await _cardsRepository.DoesNumberExist(cardContract.Number);

        if (doesNumberExist)
            return CardAddResponseCode.NumberInvalid;

        var card = CardExtensions.ToCard(cardContract);

        var response = await _cardsRepository.AddCard(card);

        return response;
    }
}