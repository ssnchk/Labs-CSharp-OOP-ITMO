namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.BankAccounts.ResultTypes;

public abstract record GetBalanceResult
{
    public sealed record Success(decimal Balance) : GetBalanceResult;

    public sealed record Failure(string Message) : GetBalanceResult;
}