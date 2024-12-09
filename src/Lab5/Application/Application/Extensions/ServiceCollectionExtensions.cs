using Itmo.ObjectOrientedProgramming.Lab5.Application.Application.AdminServices;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Application.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Application.User;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Admins;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.User;
using Microsoft.Extensions.DependencyInjection;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Application.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddScoped<IBankAccountService, BankAccountService>()
            .AddScoped<IAdminService, AdminService>()
            .AddScoped<IUserService, UserService>();

        services.AddScoped<CurrentBankAccountManager>();
        services.AddScoped<ICurrentBankAccountService>(
            provider => provider.GetRequiredService<CurrentBankAccountManager>());

        services.AddScoped<CurrentUserTypeManager>();
        services.AddScoped<ICurrentUserTypeService>(
            provider => provider.GetRequiredService<CurrentUserTypeManager>());

        return services;
    }
}