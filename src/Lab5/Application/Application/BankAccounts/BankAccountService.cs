using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstraction.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.BankAccounts.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Application.BankAccounts;

public class BankAccountService : IBankAccountService
{
    private readonly IBankAccountRepository _bankAccountRepository;

    public BankAccountService(IBankAccountRepository bankAccountRepository)
    {
        _bankAccountRepository = bankAccountRepository;
    }

    public GetBalanceResult GetBalance(long id)
    {
        BankAccount? account = _bankAccountRepository.FindBankAccountById(id);

        if (account is null)
        {
            return new GetBalanceResult.Failure("Bank account not found");
        }

        return new GetBalanceResult.Success(account.Balance);
    }

    public GetHistoryResult GetHistory(long id)
    {
        BankAccount? account = _bankAccountRepository.FindBankAccountById(id);

        if (account is null)
        {
            return new GetHistoryResult.Failure("Bank account not found");
        }

        return new GetHistoryResult.Success(account.History);
    }

    public DepositResult Deposit(long id, decimal amount)
    {
        BankAccount? account = _bankAccountRepository.FindBankAccountById(id);

        if (account is null)
        {
            return new DepositResult.Failure("Bank account not found");
        }

        account.Deposit(amount);

        if (!_bankAccountRepository.TryUpdateBankAccount(account))
            return new DepositResult.Failure("Could not update information");

        if (!CheckIsChanged(account, id))
        {
            return new DepositResult.Failure("Information was not changed");
        }

        return new DepositResult.Success();
    }

    public WithdrawResult Withdraw(long id, decimal amount)
    {
        BankAccount? account = _bankAccountRepository.FindBankAccountById(id);

        if (account is null)
        {
            return new WithdrawResult.Failure("Bank account not found");
        }

        WithdrawResult withdrawResult = account.Withdraw(amount);

        if (withdrawResult is WithdrawResult.Failure)
        {
            return withdrawResult;
        }

        if (!_bankAccountRepository.TryUpdateBankAccount(account))
            return new WithdrawResult.Failure("Could not update information");

        if (!CheckIsChanged(account, id))
        {
            return new WithdrawResult.Failure("Information was not changed");
        }

        return withdrawResult;
    }

    private bool CheckIsChanged(BankAccount changedAccount, long id)
    {
        BankAccount? account = _bankAccountRepository.FindBankAccountById(id);

        if (account is null)
        {
            return false;
        }

        return account.Balance == changedAccount.Balance;
    }
}