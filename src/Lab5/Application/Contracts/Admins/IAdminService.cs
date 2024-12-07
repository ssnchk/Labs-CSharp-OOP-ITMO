using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Admins.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Admins;

public interface IAdminService
{
    LoginResult Login(string password);

    CreateBankAccountResult CreateBankAccount(PinCode pinCode);

    ChangePasswordResult ChangePassword(string newPassword);
}