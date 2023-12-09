using Microsoft.EntityFrameworkCore;
using WebAPI.Contracts;
using WebAPI.EntityFramework.Context;
using WebAPI.Interfaces;
using WebAPI.Models;
using WebAPI.Reponses;
using WebAPI.Responses;
using WebAPI.Responses.Enums;

namespace WebAPI.Repositories;

public class UsersRepository : IUsersRepository
{
    private ApplicationDbContext _context;
    private ILogger<UsersRepository> _logger;

    
    public UsersRepository(ApplicationDbContext dbContext, ILogger<UsersRepository> logger)
    {
        _context = dbContext;
        _logger = logger;
    }

    public async Task<GetUserResponse> GetUserById(int id)
    {
        var response = new GetUserResponse()
        {
            UserResponseCode = UserResponseCode.Success
        };

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
            response.UserResponseCode = UserResponseCode.UserNotFound;
        else
            response.User = user;

        return response;
    }
    
    public async Task<GetUserResponse> GetUser(UserBaseContract userContract)
    {
        var response = new GetUserResponse()
        {
            UserResponseCode = UserResponseCode.Success
        };
        
        var user = await _context.Users.FirstOrDefaultAsync(u =>
            userContract.Username.Equals(u.Username));

        if (user == null)
            response.UserResponseCode = UserResponseCode.UserNotFound;

        if (!userContract.Password.Equals(user?.Password))
            response.UserResponseCode = UserResponseCode.PasswordNotCorrect;

        // return user
        if (response.UserResponseCode == UserResponseCode.Success)
            response.User = user;
        
        return response;
    }

    public async Task<UserRegisterResponse> Register(UserRegisterContract userContract)
    {
        var userRegisterResponse = new UserRegisterResponse()
        {
            UserId = 0
        };
        
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var user = new User()
                {
                    Username = userContract.Username,
                    Password = userContract.Password,
                    Email = userContract.Email
                };
                
                var userAdded = await _context.Users.AddAsync(user);

                if (userAdded.State != EntityState.Added)
                    throw new Exception();
                
                await _context.SaveChangesAsync();

                userRegisterResponse.UserId = user.Id;
                
                await transaction.CommitAsync();

                userRegisterResponse.UserRegisterResponseCode = UserRegisterResponseCode.Success;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                userRegisterResponse.UserRegisterResponseCode = UserRegisterResponseCode.Fail;
            }
        }

        return userRegisterResponse;
    }
}