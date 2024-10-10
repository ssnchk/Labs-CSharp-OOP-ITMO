namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public class Time
{
    public double TimeValue { get; }

    public Time(double time)
    {
        string timeExceptionMessage = "Time must be positive number";
        if (time < 0)
            throw new ArgumentOutOfRangeException(timeExceptionMessage);
        TimeValue = time;
    }

    public static Time operator +(Time time1, Time time2)
    {
        return new Time(time1.TimeValue + time2.TimeValue);
    }

    public static Time operator *(Time time1, Time time2)
    {
        return new Time(time1.TimeValue * time2.TimeValue);
    }

    public static bool operator >(Time time1, Time time2)
    {
        return time1.TimeValue > time2.TimeValue;
    }

    public static bool operator <(Time time1, Time time2)
    {
        return time1.TimeValue < time2.TimeValue;
    }

    public static bool operator >=(Time time1, Time time2)
    {
        return time1.TimeValue >= time2.TimeValue;
    }

    public static bool operator <=(Time time1, Time time2)
    {
        return time1.TimeValue <= time2.TimeValue;
    }
}