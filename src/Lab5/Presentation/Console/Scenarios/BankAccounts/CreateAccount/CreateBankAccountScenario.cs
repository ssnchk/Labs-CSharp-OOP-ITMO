using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Admins;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Admins.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.BankAccounts.CreateAccount;

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

        CreateBankAccountResult result = _service.CreateBankAccount(new PinCode(pinCode));

        string message = result switch
        {
            CreateBankAccountResult.Success success => $"Successfully created a new bank account with id: {success.BankAccount.Id}",
            CreateBankAccountResult.Failure failure => failure.Message,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}