using Lab5.Abstraction.Repositories;
using Lab5.Contracts.BankAccounts;
using Lab5.Models.BankAccounts.Operations;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.BankAccounts.CheckHistory;

public class CheckHistoryScenario : IScenario
{
    private readonly IBankAccountOperationsRepository _service;
    private readonly ICurrentBankAccountService _currentBankAccount;

    public CheckHistoryScenario(IBankAccountOperationsRepository service, ICurrentBankAccountService currentBankAccount)
    {
        _service = service;
        _currentBankAccount = currentBankAccount;
    }

    public string Name => "Check History";

    public void Run()
    {
        if (_currentBankAccount.AccountId is null)
            throw new ArgumentOutOfRangeException(nameof(_currentBankAccount.AccountId));

        IEnumerable<Operation> operations = _service
            .GetOperationsByAccountId(_currentBankAccount.AccountId.Value);

        foreach (Operation operation in operations)
        {
            AnsiConsole.
                WriteLine($"Date: {operation.Date} | Type: {operation.Type} | Amount: {operation.Amount}");
        }

        AnsiConsole.Ask<string>("Ok");
    }
}