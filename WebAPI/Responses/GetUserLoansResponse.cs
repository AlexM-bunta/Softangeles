using WebAPI.Models;
using WebAPI.Responses.Enums;

namespace WebAPI.Responses;

public class GetUserLoansResponse
{
    public UserLoansResponseCode UserLoansResponseCode { get; set; }
    public List<Loan> Loans { get; set; }
}