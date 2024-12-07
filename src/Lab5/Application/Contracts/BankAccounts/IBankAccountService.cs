using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.BankAccounts.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.BankAccounts;

public interface IBankAccountService
{
    GetBalanceResult GetBalance(long id);

    GetHistoryResult GetHistory(long id);

    DepositResult Deposit(long id, decimal amount);

    WithdrawResult Withdraw(long id, decimal amount);
}