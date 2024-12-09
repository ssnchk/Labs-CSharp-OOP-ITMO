using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.AdminPassword;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.BankAccounts.CheckBalance;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.BankAccounts.CheckHistory;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.BankAccounts.CreateAccount;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.BankAccounts.Deposit;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.BankAccounts.Withdraw;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.Login.LoginAsAdmin;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Scenarios.Login.LoginAsClient;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, AdminLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ClientLoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckHistoryScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateBankAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DepositScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ChangeAdminPasswordScenarioProvider>();

        return collection;
    }
}