using Microsoft.EntityFrameworkCore;
using WebAPI.EntityFramework.Context;
using WebAPI.Extensions;
using WebAPI.Interfaces;
using WebAPI.Models;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace WebAPI.Repositories;

public class SessionsRepository : ISessionsRepository
{
    private readonly ApplicationDbContext _context;
    private ILogger<SessionsRepository> _logger;

    public SessionsRepository(ApplicationDbContext dbContext, ILogger<SessionsRepository> logger)
    {
        _context = dbContext;
        _logger = logger;
    }

    public async Task<bool> CheckActiveSession(int sessionTableId)
    {
        var session = await _context.Sessions.FirstOrDefaultAsync(s => s.Id == sessionTableId && s.EndDate != null);

        return session != null;
    }
    
    public async Task<bool> CheckActiveSession(Guid sessionId)
    {
        var session = await _context.Sessions.FirstOrDefaultAsync(s => s.SessionId == sessionId);

        return session.EndDate == null;
    }
    
    public async Task<bool> CheckActiveSessionByUser(User user)
    {
        var userSession = await _context.UserSessions.FirstOrDefaultAsync(us => us.UserId == user.Id);

        if (userSession == null)
            return false;

        return await this.CheckActiveSession(userSession.SessionTableId);
    }

    public async Task<Session?> GetNewSessionByUser(User user)
    {
        Session? sessionToReturn = null;
        
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var session = new Session()
                {
                    SessionId = Guid.NewGuid(),
                    StartDate = DateTime.Now,
                    LastActiveDate = DateTime.Now
                };

                var sessionAdded = await _context.Sessions.AddAsync(session);

                if (sessionAdded.State != EntityState.Added)
                    throw new Exception();

                var userSession = new User_Sessions()
                {
                    SessionTableId = sessionAdded.Entity.Id,
                    UserId = user.Id
                };

                var userSessionAdded = await _context.UserSessions.AddAsync(userSession);

                if (userSessionAdded.State != EntityState.Added)
                    throw new Exception();

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                sessionToReturn = sessionAdded.Entity;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                sessionToReturn = null;
            }
        }

        return sessionToReturn;
    }

    public async Task<bool> StopSession(Guid guid)
    {
        using (var transaction = await _context.Database.BeginTransactionAsync())
        {
            try
            {
                var session = await _context.Sessions.FirstOrDefaultAsync(s => s.SessionId == guid);

                session.EndDate = DateTimeExtensions.SetKindUtc(DateTime.Now);
                session.LastActiveDate = DateTimeExtensions.SetKindUtc(DateTime.Now);;
                
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}