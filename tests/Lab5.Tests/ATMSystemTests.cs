using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstraction.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Application.BankAccounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;
using NSubstitute;
using Xunit;

namespace Lab5.Tests;

public class ATMSystemTests
{
    [Fact]
    public void WithdrawShouldChangeBalanceIfEnoughMoney()
    {
        // Arrange
        IBankAccountRepository mockRepository = Substitute.For<IBankAccountRepository>();

        var account = new BankAccount(1, new PinCode("1234"), 100, []);
        mockRepository.FindBankAccountById(1).Returns(account);

        var service = new BankAccountService(mockRepository);

        // Act
        service.Withdraw(1, 99);

        // Assert
        Assert.Equal(1, account.Balance);
        mockRepository.Received(1).TryUpdateBankAccount(account);
    }

    [Fact]
    public void WithdrawShouldNotChangeBalanceIfNotEnoughMoney()
    {
        // Arrange
        IBankAccountRepository mockRepository = Substitute.For<IBankAccountRepository>();

        var account = new BankAccount(1, new PinCode("1234"), 98, []);
        mockRepository.FindBankAccountById(1).Returns(account);

        var service = new BankAccountService(mockRepository);

        // Act
        service.Withdraw(1, 99);

        // Assert
        Assert.Equal(98, account.Balance);
        mockRepository.Received(0).TryUpdateBankAccount(account);
    }

    [Fact]
    public void DepositShouldChangeBalance()
    {
        // Arrange
        IBankAccountRepository mockRepository = Substitute.For<IBankAccountRepository>();

        var account = new BankAccount(1, new PinCode("1234"), 100, []);
        mockRepository.FindBankAccountById(1).Returns(account);

        var service = new BankAccountService(mockRepository);

        // Act
        service.Deposit(1, 100);

        // Assert
        Assert.Equal(200, account.Balance);
        mockRepository.Received(1).TryUpdateBankAccount(account);
    }
}