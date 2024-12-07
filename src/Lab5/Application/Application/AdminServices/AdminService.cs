using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstraction.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Application.User;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Admins;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Admins.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Application.AdminServices;

public class AdminService : IAdminService
{
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly IAdminPasswordRepository _adminPasswordRepository;
    private readonly CurrentUserTypeManager _currentUserTypeService;

    public AdminService(
        IBankAccountRepository bankAccountRepository,
        IAdminPasswordRepository adminPasswordRepository,
        CurrentUserTypeManager currentUserTypeService)
    {
        _bankAccountRepository = bankAccountRepository;
        _adminPasswordRepository = adminPasswordRepository;
        _currentUserTypeService = currentUserTypeService;
    }

    public LoginResult Login(string password)
    {
        string? adminPassword = _adminPasswordRepository.GetAdminPassword();

        if (adminPassword is null)
            return new LoginResult.Failure("Could not get admin password");

        if (adminPassword != password)
            return new LoginResult.Failure("Wrong password");

        _currentUserTypeService.User = UserType.Admin;

        return new LoginResult.Success();
    }

    public CreateBankAccountResult CreateBankAccount(PinCode pinCode)
    {
        BankAccount? newAccount = _bankAccountRepository.CreateBankAccount(pinCode);

        if (newAccount is null)
            return new CreateBankAccountResult.Failure("Could not create account");

        if (_bankAccountRepository.FindBankAccountById(newAccount.Id) == null)
            return new CreateBankAccountResult.Failure("Account was not created");

        return new CreateBankAccountResult.Success(newAccount);
    }

    public ChangePasswordResult ChangePassword(string newPassword)
    {
        if (!_adminPasswordRepository.TrySetPassword(newPassword))
            return new ChangePasswordResult.Failure("Could not set new password");

        return new ChangePasswordResult.Success();
    }
}