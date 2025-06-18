using Lab5.Contracts.Admins.ResultTypes;
using Lab5.Models.BankAccounts;

namespace Lab5.Contracts.User;

public interface IUserService
{
    LoginResult Login(long bankAccountId, PinCode password);

    LogoutResult Logout();
}