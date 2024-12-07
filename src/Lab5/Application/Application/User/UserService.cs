using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstraction.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Application.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Admins.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.User;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Application.User;

public class UserService : IUserService
{
    private readonly IBankAccountRepository _bankAccountRepository;
    private readonly CurrentUserTypeManager _currentUserTypeManager;
    private readonly CurrentBankAccountManager _currentBankAccountManager;

    public UserService(
        IBankAccountRepository bankAccountRepository,
        CurrentBankAccountManager currentUserTypeManager,
        CurrentUserTypeManager currentBankAccountManager)
    {
        _bankAccountRepository = bankAccountRepository;
        _currentUserTypeManager = currentBankAccountManager;
        _currentBankAccountManager = currentUserTypeManager;
    }

    public LoginResult Login(long bankAccountId, PinCode password)
    {
        BankAccount? account = _bankAccountRepository.FindBankAccountById(bankAccountId);

        if (account is null)
        {
            return new LoginResult.Failure("Bank account not found");
        }

        if (account.PinCode.Value != password.Value)
        {
            return new LoginResult.Failure("Wrong pin code");
        }

        _currentUserTypeManager.User = UserType.Client;
        _currentBankAccountManager.AccountId = bankAccountId;

        return new LoginResult.Success();
    }
}