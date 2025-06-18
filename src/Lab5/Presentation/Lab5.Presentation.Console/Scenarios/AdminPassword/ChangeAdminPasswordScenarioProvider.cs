using Lab5.Contracts.Admins;
using Lab5.Contracts.User;
using Lab5.Models.Users;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.AdminPassword;

public class ChangeAdminPasswordScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentUserTypeService _currentUser;

    public ChangeAdminPasswordScenarioProvider(IAdminService service, ICurrentUserTypeService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not UserType.Admin)
        {
            scenario = null;
            return false;
        }

        scenario = new ChangeAdminPasswordScenario(_service);
        return true;
    }
}