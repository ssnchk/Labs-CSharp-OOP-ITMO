using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Admins.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.User;

public interface IUserService
{
    LoginResult Login(long bankAccountId, PinCode password);
}