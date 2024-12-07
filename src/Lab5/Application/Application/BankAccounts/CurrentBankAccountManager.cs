using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.BankAccounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Application.BankAccounts;

public class CurrentBankAccountManager : ICurrentBankAccountService
{
    public long? AccountId { get; set; }
}