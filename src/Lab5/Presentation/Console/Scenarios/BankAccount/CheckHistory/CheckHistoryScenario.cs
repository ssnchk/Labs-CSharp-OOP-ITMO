using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.BankAccounts.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts.Operations;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.BankAccount.CheckHistory;

public class CheckHistoryScenario : IScenario
{
    private readonly IBankAccountService _service;
    private readonly ICurrentBankAccountService _currentBankAccount;

    public CheckHistoryScenario(IBankAccountService service, ICurrentBankAccountService currentBankAccount)
    {
        _service = service;
        _currentBankAccount = currentBankAccount;
    }

    public string Name => "Check History";

    public void Run()
    {
        if (_currentBankAccount.AccountId is null)
            throw new ArgumentOutOfRangeException(nameof(_currentBankAccount.AccountId));

        GetHistoryResult result = _service
            .GetHistory(_currentBankAccount.AccountId.Value);

        if (result is GetHistoryResult.Failure failure)
        {
            AnsiConsole.WriteLine(failure.Message);
            return;
        }

        if (result is not GetHistoryResult.Success success)
            throw new ArgumentOutOfRangeException(nameof(result));

        IReadOnlyCollection<Operation> operations = success.History;

        foreach (Operation operation in operations)
        {
            AnsiConsole.
                WriteLine($"Date: {operation.Date} | Type: {operation.Type} | Amount: {operation.Amount}");
        }

        AnsiConsole.Ask<string>("Ok");
    }
}