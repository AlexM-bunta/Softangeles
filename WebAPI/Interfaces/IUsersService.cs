using WebAPI.Contracts;
using WebAPI.Models;
using WebAPI.Reponses;

namespace WebAPI.Interfaces;

public interface IUsersService
{
    Task<LoginResponse> Login(UserBaseContract userBaseContract);
    Task<bool> Logout(Guid guid);
    Task<bool> Register(UserRegisterContract userRegisterContract);
}