using Lab5.Contracts.Admins.ResultTypes;
using Lab5.Contracts.User;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Authentication.ClientLogout;

public class ClientLogoutScenario : IScenario
{
    private readonly IUserService _userService;

    public ClientLogoutScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Logout";

    public void Run()
    {
        LogoutResult result = _userService.Logout();

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