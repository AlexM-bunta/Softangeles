using WebAPI.Contracts;
using WebAPI.Extensions;
using WebAPI.Interfaces;
using WebAPI.Responses;
using WebAPI.Responses.Enums;

namespace WebAPI.Services;

public class UsersService : IUsersService
{
    private readonly IUsersRepository _usersRepository;
    private readonly ISessionsRepository _sessionsRepository;
    private ILogger<UsersService> _logger;

    public UsersService(IUsersRepository usersRepo, ISessionsRepository sessionsRepo, ILogger<UsersService> logger)
    {
        _usersRepository = usersRepo;
        _sessionsRepository = sessionsRepo;
        _logger = logger;
    }

    public async Task<GetUserDetailsResponse> GetUserDetails(Guid guid)
    {
        var userId = await _sessionsRepository.GetActiveUserIdBySession(guid);

        var getUserResponse = await _usersRepository.GetUserById(userId);

        var getUserDetailsResponse = new GetUserDetailsResponse()
        {
            UserResponseCode = getUserResponse.UserResponseCode,
            UserDetails = UsersExtensions.ToDetails(getUserResponse.User)
        };
        
        return getUserDetailsResponse;
    }

    public async Task<LoginResponse> Login(UserBaseContract userContract)
    {
        var loginResponse = new LoginResponse()
        {
            UserResponseCode = UserResponseCode.Success
        };
        
        var getUserResponse = await _usersRepository.GetUser(userContract);

        loginResponse.UserResponseCode = getUserResponse.UserResponseCode;

        // if not successful, return
        if (loginResponse.UserResponseCode != UserResponseCode.Success)
            return loginResponse;
        
        var activeSession = await _sessionsRepository.CheckActiveSessionByUser(getUserResponse.User);

        if (activeSession)
        {
            loginResponse.UserResponseCode = UserResponseCode.SessionActive;
        }

        var newSession = await _sessionsRepository.GetNewSessionByUser(getUserResponse.User);
        
        if (newSession != null)
            loginResponse.SessionId = newSession.SessionId;
        
        return loginResponse;
    }

    public async Task<bool> Logout(Guid guid)
    {
        var isSessionActive = await _sessionsRepository.CheckActiveSession(guid);

        if (!isSessionActive)
            return true;
        
        var logoutSuccessful = await _sessionsRepository.StopSession(guid);

        return logoutSuccessful;
    }

    public async Task<bool> Register(UserRegisterContract userContract)
    {
        var existingUser = await _usersRepository.GetUser(userContract);

        if (existingUser.UserResponseCode == UserResponseCode.Success)
            return false;
        
        var registerSuccessful = await _usersRepository.Register(userContract);

        return registerSuccessful;
    }
}