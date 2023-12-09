using WebAPI.Models;

namespace WebAPI.Interfaces;

public interface ISessionsRepository
{
    Task<bool> CheckActiveSession(int sessionTableId);
    Task<bool> CheckActiveSession(Guid sessionId);
    Task<bool> CheckActiveSessionByUser(User user);
    Task<Session?> GetNewSessionByUser(User user);
    Task<bool> StopSession(Guid guid);
}