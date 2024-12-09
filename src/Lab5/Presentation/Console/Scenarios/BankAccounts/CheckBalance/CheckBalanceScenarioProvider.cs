using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.User;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;
using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.BankAccounts.CheckBalance;

public class CheckBalanceScenarioProvider : IScenarioProvider
{
    private readonly IBankAccountService _service;
    private readonly ICurrentUserTypeService _currentUser;
    private readonly ICurrentBankAccountService _currentAccountService;

    public CheckBalanceScenarioProvider(
        IBankAccountService service,
        ICurrentUserTypeService currentUser,
        ICurrentBankAccountService currentAccountService)
    {
        _service = service;
        _currentUser = currentUser;
        _currentAccountService = currentAccountService;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not UserType.Client)
        {
            scenario = null;
            return false;
        }

        scenario = new CheckBalanceScenario(_service, _currentAccountService);
        return true;
    }
}