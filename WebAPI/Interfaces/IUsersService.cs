using WebAPI.Contracts;
using WebAPI.Responses;

namespace WebAPI.Interfaces;

public interface IUsersService
{
    Task<GetUserDetailsResponse> GetUserDetails(Guid guid);
    Task<LoginResponse> Login(UserBaseContract userBaseContract);
    Task<bool> Logout(Guid guid);
    Task<bool> Register(UserRegisterContract userRegisterContract);
}