namespace Lab5.Models.BankAccounts.Operations;

public record Operation(OperationType Type, decimal Amount, DateTime Date, long BankAccountId);