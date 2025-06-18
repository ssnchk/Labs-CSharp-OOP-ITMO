using Lab5.Contracts.User;
using Lab5.Models.Users;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.Authentication.ClientLogout;

public class ClientLogoutScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserTypeService _currentUserTypeService;
    private readonly IUserService _userService;

    public ClientLogoutScenarioProvider(ICurrentUserTypeService currentUserTypeService, IUserService userService)
    {
        _currentUserTypeService = currentUserTypeService;
        _userService = userService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserTypeService.User is not UserType.Client)
        {
            scenario = null;
            return false;
        }

        scenario = new ClientLogoutScenario(_userService);

        return true;
    }
}