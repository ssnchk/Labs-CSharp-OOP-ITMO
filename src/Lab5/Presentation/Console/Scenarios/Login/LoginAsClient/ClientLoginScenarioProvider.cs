using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.User;
using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.Login.LoginAsClient;

public class ClientLoginScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserTypeService _currentUser;

    public ClientLoginScenarioProvider(
        IUserService service,
        ICurrentUserTypeService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new ClientLoginScenario(_service);
        return true;
    }
}