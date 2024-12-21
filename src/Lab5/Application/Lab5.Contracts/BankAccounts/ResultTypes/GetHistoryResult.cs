using Lab5.Models.BankAccounts.Operations;

namespace Lab5.Contracts.BankAccounts.ResultTypes;

public abstract record GetHistoryResult
{
    public sealed record Success(IReadOnlyCollection<Operation> History) : GetHistoryResult;

    public sealed record Failure(string Message) : GetHistoryResult;
}