using Lab5.Abstraction.Repositories;
using Lab5.Contracts.BankAccounts;
using Lab5.Contracts.BankAccounts.ResultTypes;
using Lab5.Models.BankAccounts;
using Lab5.Models.BankAccounts.Operations;

namespace Lab5.Application.BankAccounts;

public class BankAccountService : IBankAccountService
{
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly IBankAccountOperationsService _bankAccountOperationsService;

    public BankAccountService(
        IBankAccountRepository bankAccountRepository,
        IBankAccountOperationsService bankAccountOperationsService)
    {
        _bankAccountRepository = bankAccountRepository;
        _bankAccountOperationsService = bankAccountOperationsService;
    }

    public GetBalanceResult GetBalance(long id)
    {
        BankAccount? account = _bankAccountRepository.FindBankAccountById(id);

        if (account is null)
        {
            return new GetBalanceResult.Failure("Bank account not found");
        }

        return new GetBalanceResult.Success(account.Value.Balance);
    }

    public DepositResult Deposit(long id, decimal amount)
    {
        BankAccount? account = _bankAccountRepository.FindBankAccountById(id);

        if (account is null)
        {
            return new DepositResult.Failure("Bank account not found");
        }

        BankAccount newAccount = account.Value with { Balance = account.Value.Balance + amount };

        if (!_bankAccountRepository.TryUpdateBankAccount(newAccount))
            return new DepositResult.Failure("Could not update information");

        if (!CheckIsChanged(newAccount, id))
        {
            return new DepositResult.Failure("Information was not changed");
        }

        if (_bankAccountOperationsService
                .TryAddOperation(new Operation(OperationType.Deposit, amount, DateTime.Now, id)) is
            AddOperationResult.Failure failure)
        {
            return new DepositResult.Failure(failure.Message);
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

        if (account.Value.Balance < amount)
            return new WithdrawResult.Failure("Not enough money");

        BankAccount newAccount = account.Value with { Balance = account.Value.Balance - amount };

        if (!_bankAccountRepository.TryUpdateBankAccount(newAccount))
            return new WithdrawResult.Failure("Could not update information");

        if (!CheckIsChanged(newAccount, id))
        {
            return new WithdrawResult.Failure("Information was not changed");
        }

        if (_bankAccountOperationsService
                .TryAddOperation(new Operation(OperationType.Deposit, amount, DateTime.Now, id)) is
            AddOperationResult.Failure failure)
        {
            return new WithdrawResult.Failure(failure.Message);
        }

        return new WithdrawResult.Success();
    }

    private bool CheckIsChanged(BankAccount changedBankAccount, long id)
    {
        BankAccount? account = _bankAccountRepository.FindBankAccountById(id);

        if (account is null)
        {
            return false;
        }

        return account.Value.Balance == changedBankAccount.Balance;
    }
}