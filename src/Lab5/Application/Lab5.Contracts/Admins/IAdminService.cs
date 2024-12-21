using Lab5.Contracts.Admins.ResultTypes;
using Lab5.Models.BankAccounts;

namespace Lab5.Contracts.Admins;

public interface IAdminService
{
    LoginResult Login(string password);

    LogoutResult Logout();

    CreateBankAccountResult CreateBankAccount(long id, PinCode pinCode);

    ChangePasswordResult ChangePassword(string newPassword);
}