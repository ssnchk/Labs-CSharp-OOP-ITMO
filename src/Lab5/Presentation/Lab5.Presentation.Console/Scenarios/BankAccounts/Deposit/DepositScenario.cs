using Lab5.Contracts.BankAccounts;
using Lab5.Contracts.BankAccounts.ResultTypes;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.BankAccounts.Deposit;

public class DepositScenario : IScenario
{
    private readonly IBankAccountService _service;
    private readonly ICurrentBankAccountService _currentBankAccount;

    public DepositScenario(IBankAccountService service, ICurrentBankAccountService currentBankAccount)
    {
        _service = service;
        _currentBankAccount = currentBankAccount;
    }

    public string Name => "Deposit";

    public void Run()
    {
        if (_currentBankAccount.AccountId is null)
            throw new ArgumentOutOfRangeException(nameof(_currentBankAccount.AccountId));

        long depositAmount = AnsiConsole.Ask<long>("Enter deposit amount");

        DepositResult result = _service
            .Deposit(_currentBankAccount.AccountId.Value, depositAmount);

        string message = result switch
        {
            DepositResult.Success => "Successful deposit",
            DepositResult.Failure failure => failure.Message,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}