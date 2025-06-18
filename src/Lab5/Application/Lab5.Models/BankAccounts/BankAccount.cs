namespace Lab5.Models.BankAccounts;

public record struct BankAccount(long Id, PinCode Code, decimal Balance);