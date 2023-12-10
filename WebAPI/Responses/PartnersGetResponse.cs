using WebAPI.Models;
using WebAPI.Responses.Enums;

namespace WebAPI.Responses;

public class PartnersGetResponse
{
    public List<Partner> Partners { get; set; }
    public BaseResponseCode BaseResponseCode { get; set; }
}