namespace Itmo.ObjectOrientedProgramming.Lab4.ValueTypes;

public class TreeDepth
{
    public static TreeDepth One => new(1);

    public TreeDepth(int value)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(value);

        Value = value;
    }

    public int Value { get; }
}