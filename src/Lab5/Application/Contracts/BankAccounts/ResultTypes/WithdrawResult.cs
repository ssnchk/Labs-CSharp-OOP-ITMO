namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.BankAccounts.ResultTypes;

public abstract record WithdrawResult
{
    public sealed record Success : WithdrawResult;

    public sealed record Failure(string Message) : WithdrawResult;
}