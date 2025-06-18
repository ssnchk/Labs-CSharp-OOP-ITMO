using Lab5.Presentation.Console.Scenarios;
using Lab5.Presentation.Console.Scenarios.AdminPassword;
using Lab5.Presentation.Console.Scenarios.Authentication.AdminLogout;
using Lab5.Presentation.Console.Scenarios.Authentication.ClientLogout;
using Lab5.Presentation.Console.Scenarios.Authentication.LoginAsAdmin;
using Lab5.Presentation.Console.Scenarios.Authentication.LoginAsClient;
using Lab5.Presentation.Console.Scenarios.BankAccounts.CheckBalance;
using Lab5.Presentation.Console.Scenarios.BankAccounts.CheckHistory;
using Lab5.Presentation.Console.Scenarios.BankAccounts.CreateAccount;
using Lab5.Presentation.Console.Scenarios.BankAccounts.Deposit;
using Lab5.Presentation.Console.Scenarios.BankAccounts.Withdraw;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

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
        collection.AddScoped<IScenarioProvider, ClientLogoutScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AdminLogoutScenarioProvider>();

        return collection;
    }
}