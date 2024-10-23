namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public class SemesterNumber
{
    public int Value { get; }

    public SemesterNumber(int value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);
        Value = value;
    }
}