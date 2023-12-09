using WebAPI.Models;
using WebAPI.Responses.Enums;

namespace WebAPI.Reponses;

public class GetUserResponse
{
    public User? User { get; set; }
    public UserResponseCode UserResponseCode { get; set; }
}