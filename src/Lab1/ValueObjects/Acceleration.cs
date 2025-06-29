﻿namespace Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

public class Acceleration
{
    public static Acceleration Zero { get; } = new Acceleration(0);

    public double AccelerationValue { get; }

    public Acceleration(double acceleration)
    {
        AccelerationValue = acceleration;
    }

    public static Acceleration operator +(Acceleration acceleration1, Acceleration acceleration2)
    {
        return new Acceleration(acceleration1.AccelerationValue + acceleration2.AccelerationValue);
    }

    public static bool operator >(Acceleration acceleration1, Acceleration acceleration2)
    {
        return acceleration1.AccelerationValue > acceleration2.AccelerationValue;
    }

    public static bool operator <(Acceleration acceleration1, Acceleration acceleration2)
    {
        return acceleration1.AccelerationValue < acceleration2.AccelerationValue;
    }

    public static bool operator >=(Acceleration acceleration1, Acceleration acceleration2)
    {
        return acceleration1.AccelerationValue >= acceleration2.AccelerationValue;
    }

    public static bool operator <=(Acceleration acceleration1, Acceleration acceleration2)
    {
        return acceleration1.AccelerationValue <= acceleration2.AccelerationValue;
    }
}