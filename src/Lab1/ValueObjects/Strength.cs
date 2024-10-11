namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public class Strength
{
    public static Strength Zero { get; } = new Strength(0);

    public double StrengthValue { get; }

    public Strength(double strength)
    {
        StrengthValue = strength;
    }

    public static Strength operator +(Strength strength1, Strength strength2)
    {
        return new Strength(strength1.StrengthValue + strength2.StrengthValue);
    }

    public static bool operator >(Strength strength1, Strength strength2)
    {
        return strength1.StrengthValue > strength2.StrengthValue;
    }

    public static bool operator <(Strength strength1, Strength strength2)
    {
        return strength1.StrengthValue < strength2.StrengthValue;
    }

    public static bool operator >=(Strength strength1, Strength strength2)
    {
        return strength1.StrengthValue >= strength2.StrengthValue;
    }

    public static bool operator <=(Strength strength1, Strength strength2)
    {
        return strength1.StrengthValue <= strength2.StrengthValue;
    }

    public static Acceleration operator /(Strength strength, Weight weight)
    {
        return new Acceleration(strength.StrengthValue / weight.WeightValue);
    }
}