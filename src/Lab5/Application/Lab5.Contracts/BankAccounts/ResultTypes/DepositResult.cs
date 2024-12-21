namespace Lab5.Contracts.BankAccounts.ResultTypes;

public abstract record DepositResult
{
    public sealed record Success : DepositResult;

    public sealed record Failure(string Message) : DepositResult;
}