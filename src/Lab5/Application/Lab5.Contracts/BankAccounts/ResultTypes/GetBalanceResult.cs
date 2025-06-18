namespace Lab5.Contracts.BankAccounts.ResultTypes;

public abstract record GetBalanceResult
{
    public sealed record Success(decimal Balance) : GetBalanceResult;

    public sealed record Failure(string Message) : GetBalanceResult;
}