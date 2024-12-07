using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstraction.Repositories;

public interface IBankAccountRepository
{
    BankAccount? FindBankAccountById(long id);

    bool TryUpdateBankAccount(BankAccount bankAccount);

    BankAccount? CreateBankAccount(PinCode pinCode);
}