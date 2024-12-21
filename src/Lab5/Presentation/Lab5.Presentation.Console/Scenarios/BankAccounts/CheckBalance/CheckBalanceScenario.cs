using Lab5.Contracts.BankAccounts;
using Lab5.Contracts.BankAccounts.ResultTypes;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.BankAccounts.CheckBalance;

public class CheckBalanceScenario : IScenario
{
    private readonly IBankAccountService _service;
    private readonly ICurrentBankAccountService _currentBankAccount;

    public CheckBalanceScenario(IBankAccountService service, ICurrentBankAccountService currentBankAccount)
    {
        _service = service;
        _currentBankAccount = currentBankAccount;
    }

    public string Name => "Check Balance";

    public void Run()
    {
        if (_currentBankAccount.AccountId is null)
            throw new ArgumentOutOfRangeException(nameof(_currentBankAccount.AccountId));

        GetBalanceResult balance = _service
            .GetBalance(_currentBankAccount.AccountId.Value);

        string message = balance switch
        {
            GetBalanceResult.Success success => $"Balance: {success.Balance}",
            GetBalanceResult.Failure failure => failure.Message,
            _ => throw new ArgumentOutOfRangeException(nameof(balance)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}