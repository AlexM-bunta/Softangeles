using WebAPI.Contracts;
using WebAPI.Responses;
using WebAPI.Responses.Enums;

namespace WebAPI.Interfaces;

public interface ILoansRepository
{
    Task<GetUserLoansResponse> GetUserLoans(int userId);
    Task<UserLoansResponseCode> AddLoan(LoanAddContract loanContract);
}