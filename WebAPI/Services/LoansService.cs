using WebAPI.Contracts;
using WebAPI.Interfaces;
using WebAPI.Responses;
using WebAPI.Responses.Enums;

namespace WebAPI.Services;

public class LoansService : ILoansService
{
    private readonly ILoansRepository _loansRepository;
    private readonly ISessionsRepository _sessionsRepository;
    
    public LoansService(ILoansRepository loansRepo, ISessionsRepository sessionsRepo)
    {
        _loansRepository = loansRepo;
        _sessionsRepository = sessionsRepo;
    }

    public async Task<GetUserLoansResponse> GetUserLoans(Guid sessionId)
    {
        var getUserLoansResponse = new GetUserLoansResponse()
        {
            UserLoansResponseCode = UserLoansResponseCode.Success
        };

        var userId = await _sessionsRepository.GetActiveUserIdBySession(sessionId);

        if (userId == 0)
            getUserLoansResponse.UserLoansResponseCode = UserLoansResponseCode.UserNotFound;
        else
            getUserLoansResponse = await _loansRepository.GetUserLoans(userId);

        return getUserLoansResponse;
    }

    public async Task<UserLoansResponseCode> AddLoan(LoanAddWithSessionContract loanContract)
    {
        var userId = await _sessionsRepository.GetActiveUserIdBySession(loanContract.SessionId);

        if (userId == 0)
            return UserLoansResponseCode.UserNotFound;

        LoanAddContract loanAddContract = new LoanAddContract()
        {
            UserId = userId,
            Interest = loanContract.Interest,
            Months = loanContract.Months,
            RequestedAmount = loanContract.RequestedAmount,
            TotalAmount = loanContract.TotalAmount
        };

        var result = await _loansRepository.AddLoan(loanAddContract);

        return result;
    }
}