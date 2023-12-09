using WebAPI.Models;
using WebAPI.Models.Views;
using WebAPI.Responses.Enums;

namespace WebAPI.Responses;

public class GetCardsResponse
{
    public List<Card> CardsList { get; set; }
    public AccountResponseCode AccountResponseCode { get; set; }
}