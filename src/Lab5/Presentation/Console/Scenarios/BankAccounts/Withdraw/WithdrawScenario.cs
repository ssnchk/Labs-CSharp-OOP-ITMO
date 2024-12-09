using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.BankAccounts.ResultTypes;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.BankAccounts.Withdraw;

public class WithdrawScenario : IScenario
{
    private readonly IBankAccountService _service;
    private readonly ICurrentBankAccountService _currentBankAccount;

    public WithdrawScenario(IBankAccountService service, ICurrentBankAccountService currentBankAccount)
    {
        _service = service;
        _currentBankAccount = currentBankAccount;
    }

    public string Name => "Withdraw";

    public void Run()
    {
        if (_currentBankAccount.AccountId is null)
            throw new ArgumentOutOfRangeException(nameof(_currentBankAccount.AccountId));

        long withdrawAmount = AnsiConsole.Ask<long>("Enter withdraw amount");

        WithdrawResult result = _service
            .Withdraw(_currentBankAccount.AccountId.Value, withdrawAmount);

        string message = result switch
        {
            WithdrawResult.Success => "Successful deposit",
            WithdrawResult.Failure failure => failure.Message,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}