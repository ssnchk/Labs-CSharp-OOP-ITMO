using Lab5.Application.AdminServices;
using Lab5.Application.BankAccounts;
using Lab5.Application.User;
using Lab5.Contracts.Admins;
using Lab5.Contracts.BankAccounts;
using Lab5.Contracts.User;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddScoped<IBankAccountService, BankAccountService>()
            .AddScoped<IAdminService, AdminService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IBankAccountOperationsService, BankAccountOperationsService>();

        services.AddScoped<CurrentBankAccountManager>();
        services.AddScoped<ICurrentBankAccountService>(
            provider => provider.GetRequiredService<CurrentBankAccountManager>());

        services.AddScoped<CurrentUserTypeManager>();
        services.AddScoped<ICurrentUserTypeService>(
            provider => provider.GetRequiredService<CurrentUserTypeManager>());

        return services;
    }
}