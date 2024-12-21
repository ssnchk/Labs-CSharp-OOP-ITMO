using Lab5.Abstraction.Repositories;
using Lab5.Application.User;
using Lab5.Contracts.Admins;
using Lab5.Contracts.Admins.ResultTypes;
using Lab5.Models.BankAccounts;
using Lab5.Models.Users;

namespace Lab5.Application.AdminServices;

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

    public LogoutResult Logout()
    {
        _currentUserTypeService.User = null;

        return new LogoutResult.Success();
    }

    public CreateBankAccountResult CreateBankAccount(long id, PinCode pinCode)
    {
        bool createResult = _bankAccountRepository.TryCreateBankAccount(id, pinCode);

        if (!createResult)
            return new CreateBankAccountResult.Failure("Could not create account");

        return new CreateBankAccountResult.Success();
    }

    public ChangePasswordResult ChangePassword(string newPassword)
    {
        if (!_adminPasswordRepository.TrySetPassword(newPassword))
            return new ChangePasswordResult.Failure("Could not set new password");

        return new ChangePasswordResult.Success();
    }
}