namespace Lab5.Contracts.BankAccounts.ResultTypes;

public abstract record AddOperationResult
{
    public sealed record Success : AddOperationResult;

    public sealed record Failure(string Message) : AddOperationResult;
}