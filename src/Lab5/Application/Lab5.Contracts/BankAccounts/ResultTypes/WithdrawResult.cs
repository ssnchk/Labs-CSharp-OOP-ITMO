namespace Lab5.Contracts.BankAccounts.ResultTypes;

public abstract record WithdrawResult
{
    public sealed record Success : WithdrawResult;

    public sealed record Failure(string Message) : WithdrawResult;
}