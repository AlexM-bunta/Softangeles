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
            AccountResponseCode = AccountResponseCode.Success
        };
        
        var cardsList = await _cardsRepository.GetCardsByAccountId(id);

        if (cardsList == null || cardsList.Count == 0)
            getCardsResponse.AccountResponseCode = AccountResponseCode.NoObjectsFound;
        else
            getCardsResponse.CardsList = cardsList;
        
        return getCardsResponse;
    }
}