using Lab5.Models.BankAccounts;

namespace Lab5.Abstraction.Repositories;

public interface IBankAccountRepository
{
    BankAccount? FindBankAccountById(long id);

    bool TryUpdateBankAccount(BankAccount bankAccount);

    bool TryCreateBankAccount(long id, PinCode pinCode);
}