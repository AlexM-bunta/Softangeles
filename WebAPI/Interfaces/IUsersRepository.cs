using WebAPI.Contracts;
using WebAPI.Reponses;
using WebAPI.Responses.Enums;

namespace WebAPI.Interfaces;

public interface IUsersRepository
{
    Task<GetUserResponse> GetUserById(int id);
    Task<GetUserResponse> GetUser(UserBaseContract userContract);
    Task<bool> Register(UserRegisterContract userContract);
}