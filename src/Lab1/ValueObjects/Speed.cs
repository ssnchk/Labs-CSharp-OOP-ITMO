namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public class Speed
{
    public static Speed Zero { get; } = new Speed(0);

    public double SpeedValue { get; }

    public Speed(double speed)
    {
        SpeedValue = speed;
    }

    public static Speed operator +(Speed speed1, Speed speed2)
    {
        return new Speed(speed1.SpeedValue + speed2.SpeedValue);
    }

    public static bool operator >(Speed speed1, Speed speed2)
    {
        return speed1.SpeedValue > speed2.SpeedValue;
    }

    public static bool operator <(Speed speed1, Speed speed2)
    {
        return speed1.SpeedValue < speed2.SpeedValue;
    }

    public static bool operator >=(Speed speed1, Speed speed2)
    {
        return speed1.SpeedValue >= speed2.SpeedValue;
    }

    public static bool operator <=(Speed speed1, Speed speed2)
    {
        return speed1.SpeedValue <= speed2.SpeedValue;
    }

    public static Distance operator *(Speed speed, Time time)
    {
        return new Distance(speed.SpeedValue * time.TimeValue);
    }
}