using Lab5.Contracts.Admins;
using Lab5.Contracts.User;
using Lab5.Models.Users;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.Authentication.AdminLogout;

public class AdminLogoutScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentUserTypeService _currentUserTypeService;

    public AdminLogoutScenarioProvider(IAdminService adminService, ICurrentUserTypeService currentUserTypeService)
    {
        _adminService = adminService;
        _currentUserTypeService = currentUserTypeService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUserTypeService.User is not UserType.Admin)
        {
            scenario = null;
            return false;
        }

        scenario = new AdminLogoutScenario(_adminService);
        return true;
    }
}