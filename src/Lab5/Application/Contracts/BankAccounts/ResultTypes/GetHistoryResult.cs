using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.BankAccounts.ResultTypes;

public abstract record GetHistoryResult
{
    public sealed record Success(IReadOnlyCollection<Operation> History) : GetHistoryResult;

    public sealed record Failure(string Message) : GetHistoryResult;
}