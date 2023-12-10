using WebAPI.Models;
using WebAPI.Responses.Enums;

namespace WebAPI.Responses;

public class GetCardsResponse
{
    public List<Card> CardsList { get; set; }
    public BaseResponseCode AccountResponseCode { get; set; }
}