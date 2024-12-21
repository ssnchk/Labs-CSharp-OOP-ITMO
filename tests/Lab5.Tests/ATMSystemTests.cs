using Lab5.Abstraction.Repositories;
using Lab5.Application.BankAccounts;
using Lab5.Contracts.BankAccounts;
using Lab5.Models.BankAccounts;
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
        IBankAccountOperationsService mockService = Substitute.For<IBankAccountOperationsService>();

        var account = new BankAccount(1, new PinCode("1234"), 100);
        mockRepository.FindBankAccountById(1).Returns(account);
        mockRepository.TryUpdateBankAccount(Arg.Any<BankAccount>()).Returns(true);

        var resultAccount = new BankAccount(1, new PinCode("1234"), 1);

        var service = new BankAccountService(mockRepository, mockService);

        // Act
        service.Withdraw(1, 99);

        // Assert
        mockRepository.Received(1)
            .TryUpdateBankAccount(
                Arg.Is<BankAccount>(a => Equals(a, resultAccount)));
    }

    [Fact]
    public void WithdrawShouldNotChangeBalanceIfNotEnoughMoney()
    {
        // Arrange
        IBankAccountRepository mockRepository = Substitute.For<IBankAccountRepository>();
        IBankAccountOperationsService mockService = Substitute.For<IBankAccountOperationsService>();

        var account = new BankAccount(1, new PinCode("1234"), 98);
        mockRepository.FindBankAccountById(1).Returns(account);

        var service = new BankAccountService(mockRepository, mockService);

        // Act
        service.Withdraw(1, 99);

        // Assert
        mockRepository.Received(0).TryUpdateBankAccount(account);
    }

    [Fact]
    public void DepositShouldChangeBalance()
    {
        // Arrange
        IBankAccountRepository mockRepository = Substitute.For<IBankAccountRepository>();
        IBankAccountOperationsService mockService = Substitute.For<IBankAccountOperationsService>();

        var account = new BankAccount(1, new PinCode("1234"), 100);
        mockRepository.FindBankAccountById(1).Returns(account);

        var resultAccount = new BankAccount(1, new PinCode("1234"), 200);

        var service = new BankAccountService(mockRepository, mockService);

        // Act
        service.Deposit(1, 100);

        // Assert
        mockRepository.Received(1)
            .TryUpdateBankAccount(
                Arg.Is<BankAccount>(a => Equals(a, resultAccount)));
    }
}