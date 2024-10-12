namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public class Distance
{
    public static Distance Zero { get; } = new Distance(0);

    public double DistanceValue { get; }

    public Distance(double distance)
    {
        string distanceExceptionMessage = "Distance must be a positive number";
        if (distance < 0)
            throw new ArgumentOutOfRangeException(distanceExceptionMessage);
        DistanceValue = distance;
    }

    public static Distance operator +(Distance distance1, Distance distance2)
    {
        return new Distance(distance1.DistanceValue + distance2.DistanceValue);
    }

    public static bool operator >(Distance distance1, Distance distance2)
    {
        return distance1.DistanceValue > distance2.DistanceValue;
    }

    public static bool operator <(Distance distance1, Distance distance2)
    {
        return distance1.DistanceValue < distance2.DistanceValue;
    }

    public static bool operator >=(Distance distance1, Distance distance2)
    {
        return distance1.DistanceValue >= distance2.DistanceValue;
    }

    public static bool operator <=(Distance distance1, Distance distance2)
    {
        return distance1.DistanceValue <= distance2.DistanceValue;
    }
}