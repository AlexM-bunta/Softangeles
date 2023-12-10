namespace WebAPI.Responses.Enums;

public enum TransactionProcessResponseCode
{
    Successful,
    Fail,
    NotEnoughBalance,
    SourceAccountNotFound,
    DestinationAccountNotFound
}