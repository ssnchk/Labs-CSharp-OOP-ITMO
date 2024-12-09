using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Admins.ResultTypes;

public abstract record CreateBankAccountResult
{
    public sealed record Success(BankAccount BankAccount) : CreateBankAccountResult;

    public sealed record Failure(string Message) : CreateBankAccountResult;
}