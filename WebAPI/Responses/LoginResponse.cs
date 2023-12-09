using WebAPI.Responses.Enums;

namespace WebAPI.Responses;

public class LoginResponse
{
    public Guid? SessionId { get; set; }
    public UserResponseCode UserResponseCode { get; set; }
}