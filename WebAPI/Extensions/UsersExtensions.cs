using WebAPI.Models;
using WebAPI.Models.Views;

namespace WebAPI.Extensions;

public static class UsersExtensions
{
    public static UserDetails ToDetails(User user)
    {
        return new UserDetails()
        {
            EcoPoints = user.EcoPoints,
            Username = user.Username,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber
        };
    }
}