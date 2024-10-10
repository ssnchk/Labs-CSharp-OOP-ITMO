namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public class Weight
{
    public double WeightValue { get; }

    public Weight(double weight)
    {
        string weightExceptionMessage = "Weight must be positive number";
        if (weight < 0)
            throw new ArgumentOutOfRangeException(weightExceptionMessage);
        WeightValue = weight;
    }

    public static Weight operator +(Weight weight1, Weight weight2)
    {
        return new Weight(weight1.WeightValue + weight2.WeightValue);
    }

    public static bool operator >(Weight weight1, Weight weight2)
    {
        return weight1.WeightValue > weight2.WeightValue;
    }

    public static bool operator <(Weight weight1, Weight weight2)
    {
        return weight1.WeightValue < weight2.WeightValue;
    }

    public static bool operator >=(Weight weight1, Weight weight2)
    {
        return weight1.WeightValue >= weight2.WeightValue;
    }

    public static bool operator <=(Weight weight1, Weight weight2)
    {
        return weight1.WeightValue <= weight2.WeightValue;
    }
}