using Lab5.Contracts.BankAccounts;

namespace Lab5.Application.BankAccounts;

public class CurrentBankAccountManager : ICurrentBankAccountService
{
    public long? AccountId { get; set; }
}