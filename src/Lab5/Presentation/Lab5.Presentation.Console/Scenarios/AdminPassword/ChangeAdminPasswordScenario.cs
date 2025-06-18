using Lab5.Contracts.Admins;
using Lab5.Contracts.Admins.ResultTypes;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.AdminPassword;

public class ChangeAdminPasswordScenario : IScenario
{
    private readonly IAdminService _service;

    public ChangeAdminPasswordScenario(IAdminService service)
    {
        _service = service;
    }

    public string Name => "Change Admin Password";

    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter new password");

        ChangePasswordResult result = _service.ChangePassword(password);

        string message = result switch
        {
            ChangePasswordResult.Success => "Successfully changed password",
            ChangePasswordResult.Failure failure => failure.Message,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Ok");
    }
}