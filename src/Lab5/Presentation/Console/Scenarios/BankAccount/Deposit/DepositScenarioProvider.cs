using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.User;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;
using System.Diagnostics.CodeAnalysis;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.BankAccount.Deposit;

public class DepositScenarioProvider : IScenarioProvider
{
    private readonly IBankAccountService _service;
    private readonly ICurrentUserTypeService _currentUser;
    private readonly ICurrentBankAccountService _currentAccountService;

    public DepositScenarioProvider(IBankAccountService service, ICurrentUserTypeService currentUser, ICurrentBankAccountService currentAccountService)
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

        scenario = new DepositScenario(_service, _currentAccountService);
        return true;
    }
}