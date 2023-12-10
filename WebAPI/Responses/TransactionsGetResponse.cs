using WebAPI.Models;
using WebAPI.Responses.Enums;

namespace WebAPI.Responses;

public class TransactionsGetResponse
{
    public List<Transaction> DestinationTransactions { get; set; }
    public List<Transaction> SourceTransactions { get; set; }
    public BaseResponseCode BaseResponseCode { get; set; }
}