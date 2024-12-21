using Lab5.Contracts.Admins;
using Lab5.Contracts.Admins.ResultTypes;
using Lab5.Models.BankAccounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.BankAccounts.CreateAccount;

public class CreateBankAccountScenario : IScenario
{
    private readonly IAdminService _service;

    public CreateBankAccountScenario(
        IAdminService service)
    {
        _service = service;
    }

    public string Name => "Create Bank Account";

    public void Run()
    {
        string pinCode = AnsiConsole.Ask<string>("Enter pin code for a new bank account");
        long id = AnsiConsole.Ask<long>("Enter id of account");

        CreateBankAccountResult result = _service.CreateBankAccount(id, new PinCode(pinCode));

        string message = result switch
        {
            CreateBankAccountResult.Success => "Successfully created a new bank account",
            CreateBankAccountResult.Failure failure => failure.Message,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}