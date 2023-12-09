using WebAPI.Contracts;
using WebAPI.Reponses;
using WebAPI.Responses;

namespace WebAPI.Interfaces;

public interface IUsersRepository
{
    Task<GetUserResponse> GetUserById(int id);
    Task<GetUserResponse> GetUser(UserBaseContract userContract);
    Task<UserRegisterResponse> Register(UserRegisterContract userContract);
}