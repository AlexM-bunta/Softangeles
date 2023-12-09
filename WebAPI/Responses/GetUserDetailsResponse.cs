using WebAPI.Models.Views;
using WebAPI.Responses.Enums;

namespace WebAPI.Responses;

public class GetUserDetailsResponse
{
    public UserDetails? UserDetails { get; set; }
    public UserResponseCode UserResponseCode { get; set; }
}