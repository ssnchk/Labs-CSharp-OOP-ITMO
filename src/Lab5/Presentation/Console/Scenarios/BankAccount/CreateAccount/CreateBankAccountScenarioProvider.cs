using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Admins;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.User;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;
using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.BankAccount.CreateAccount;

public class CreateBankAccountScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentUserTypeService _currentUser;

    public CreateBankAccountScenarioProvider(IAdminService service, ICurrentUserTypeService currentUser)
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

        scenario = new CreateBankAccountScenario(_service);
        return true;
    }
}