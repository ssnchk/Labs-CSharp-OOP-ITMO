namespace Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

public class Points
{
    public double Value { get; }

    public Points(double value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);
        Value = value;
    }
}
