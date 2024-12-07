using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Admins.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.User;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;
using Spectre.Console;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.Login.LoginAsClient;

public class ClientLoginScenario : IScenario
{
    private readonly IUserService _service;

    public ClientLoginScenario(
        IUserService service)
    {
        _service = service;
    }

    public string Name => "Login as Client";

    public void Run()
    {
        long bankAccountId = AnsiConsole.Ask<long>("Enter bank account ID");
        string pincode = AnsiConsole.Ask<string>("Enter pincode");

        LoginResult result = _service.Login(bankAccountId, new PinCode(pincode));

        string message = result switch
        {
            LoginResult.Success => "Successful login as User",
            LoginResult.Failure failure => failure.Message,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}