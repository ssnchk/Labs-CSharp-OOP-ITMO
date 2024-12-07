using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.BankAccounts.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.IdGenerators;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;

public class BankAccount
{
    private readonly List<Operation> _history = [];

    public PinCode PinCode { get; }

    public IReadOnlyCollection<Operation> History => _history.AsReadOnly();

    public BankAccount(PinCode pinCode)
    {
        PinCode = pinCode;
        Id = IdGenerator.GenerateNewId();
    }

    public BankAccount(long id, PinCode pinCode, decimal balance, IEnumerable<Operation> history)
    {
        Id = id;
        PinCode = pinCode;
        _history = history.ToList();
        Balance = balance;
    }

    public long Id { get; }

    public decimal Balance { get; private set; } = 0;

    public void Deposit(decimal amount)
    {
        Balance += amount;
        _history.Add(new Operation(OperationType.Deposit, amount, DateTime.Now, Id));
    }

    public WithdrawResult Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            return new WithdrawResult.Failure("Not enough money");
        }

        Balance -= amount;

        _history.Add(new Operation(OperationType.Withdraw, amount, DateTime.Now, Id));

        return new WithdrawResult.Success();
    }
}