namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Models.BankAccounts;

public class PinCode
{
    public PinCode(string value)
    {
        if (value.Length != 4 || !value.All(char.IsDigit))
            throw new ArgumentException("PinCode must be 4 digits long");

        Value = value;
    }

    public string Value { get; }
}