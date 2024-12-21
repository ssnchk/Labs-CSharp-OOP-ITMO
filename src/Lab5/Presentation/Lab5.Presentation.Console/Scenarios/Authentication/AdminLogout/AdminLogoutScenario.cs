using Lab5.Contracts.Admins;
using Lab5.Contracts.Admins.ResultTypes;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Authentication.AdminLogout;

public class AdminLogoutScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AdminLogoutScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Logout";

    public void Run()
    {
        LogoutResult result = _adminService.Logout();

        string message = result switch
        {
            LogoutResult.Success => "Successfully logged out.",
            LogoutResult.Failure failure => failure.Message,
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);

        AnsiConsole.Ask<string>("Ok");
    }
}