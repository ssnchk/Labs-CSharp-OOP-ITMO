using Lab5.Contracts.BankAccounts.ResultTypes;

namespace Lab5.Contracts.BankAccounts;

public interface IBankAccountService
{
    GetBalanceResult GetBalance(long id);

    DepositResult Deposit(long id, decimal amount);

    WithdrawResult Withdraw(long id, decimal amount);
}