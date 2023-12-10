using WebAPI.Contracts;
using WebAPI.Responses;
using WebAPI.Responses.Enums;

namespace WebAPI.Interfaces;

public interface ILoansService
{
    Task<GetUserLoansResponse> GetUserLoans(Guid sessionId);
    Task<UserLoansResponseCode> AddLoan(LoanAddWithSessionContract loadContract);
}