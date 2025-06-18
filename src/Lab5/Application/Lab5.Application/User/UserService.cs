using Lab5.Abstraction.Repositories;
using Lab5.Application.BankAccounts;
using Lab5.Contracts.Admins.ResultTypes;
using Lab5.Contracts.User;
using Lab5.Models.BankAccounts;
using Lab5.Models.Users;

namespace Lab5.Application.User;

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

        if (account.Value.Code.Value != password.Value)
        {
            return new LoginResult.Failure("Wrong pin code");
        }

        _currentUserTypeManager.User = UserType.Client;
        _currentBankAccountManager.AccountId = bankAccountId;

        return new LoginResult.Success();
    }

    public LogoutResult Logout()
    {
        _currentUserTypeManager.User = null;
        _currentBankAccountManager.AccountId = null;

        return new LogoutResult.Success();
    }
}