using Lab5.Contracts.BankAccounts;
using Lab5.Contracts.User;
using Lab5.Models.Users;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.BankAccounts.Withdraw;

public class WithdrawScenarioProvider : IScenarioProvider
{
    private readonly IBankAccountService _service;
    private readonly ICurrentUserTypeService _currentUser;
    private readonly ICurrentBankAccountService _currentAccountService;

    public WithdrawScenarioProvider(IBankAccountService service, ICurrentUserTypeService currentUser, ICurrentBankAccountService currentAccountService)
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

        scenario = new WithdrawScenario(_service, _currentAccountService);
        return true;
    }
}