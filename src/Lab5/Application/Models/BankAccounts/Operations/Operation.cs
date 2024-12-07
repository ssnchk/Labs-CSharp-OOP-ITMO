using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.IdGenerators;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts.Operations;

public record Operation
{
    public Operation(OperationType type, decimal amount, DateTime date, long bankAccountId)
    {
        Id = IdGenerator.GenerateNewId();
        Type = type;
        Amount = amount;
        Date = date;
        BankAccountId = bankAccountId;
    }

    public Operation(long id, OperationType type, decimal amount, DateTime date, long bankAccountId)
    {
        Id = id;
        Type = type;
        Amount = amount;
        Date = date;
        BankAccountId = bankAccountId;
    }

    public long BankAccountId { get; }

    public long Id { get; }

    public OperationType Type { get; }

    public decimal Amount { get; }

    public DateTime Date { get; }
}