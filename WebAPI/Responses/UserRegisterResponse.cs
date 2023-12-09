using WebAPI.Responses.Enums;

namespace WebAPI.Responses;

public class UserRegisterResponse
{
    public UserRegisterResponseCode UserRegisterResponseCode { get; set; }
    public int UserId { get; set; }
}