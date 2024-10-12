using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Entities;

public class Train
{
    private readonly Weight _weight;
    private readonly Strength _maxStrength;
    private readonly TimeSpan _accuracy;
    private Speed _speed;
    private Acceleration _acceleration;

    public Train(Weight weight, Strength maxStrength, TimeSpan accuracy)
    {
        _weight = weight;
        _maxStrength = maxStrength;
        _accuracy = accuracy;
        _speed = Speed.Zero;
        _acceleration = Acceleration.Zero;
    }

    public ApplyForceResult ApplyForce(Strength strengthValue)
    {
        if (strengthValue > _maxStrength)
            return new ApplyForceResult.Failure();

        _acceleration = new Acceleration(strengthValue.StrengthValue / _weight.WeightValue);

        return new ApplyForceResult.Success();
    }

    public PassDistanceResult PassDistance(Distance distance)
    {
        if (_speed <= Speed.Zero && _acceleration <= Acceleration.Zero)
            return new PassDistanceResult.Failure();

        Distance distanceTraveled = Distance.Zero;
        TimeSpan passingTime = TimeSpan.Zero;

        while (distanceTraveled < distance)
        {
            passingTime += _accuracy;
            _speed += new Speed(_acceleration.AccelerationValue * _accuracy.TotalSeconds);
            if (_speed < Speed.Zero)
                return new PassDistanceResult.Failure();
            distanceTraveled += new Distance(_speed.SpeedValue * _accuracy.TotalSeconds);
        }

        return new PassDistanceResult.Success(passingTime);
    }

    public StopTrainResult StopTrain(Speed maxAllowedSpeed)
    {
        if (_speed > maxAllowedSpeed)
            return new StopTrainResult.Failure();

        return new StopTrainResult.Success();
    }
}