using Lab5.Contracts.Admins;
using Lab5.Contracts.Admins.ResultTypes;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Authentication.LoginAsAdmin;

public class AdminLoginScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminLoginScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Login as Admin";

    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter system password");

        LoginResult result = _adminService.Login(password);

        string message = result switch
        {
            LoginResult.Success => "Successful login as Admin",
            LoginResult.Failure failure => failure.Message,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);

        if (result is LoginResult.Failure)
            Environment.Exit(0);

        AnsiConsole.Ask<string>("Ok");
    }
}