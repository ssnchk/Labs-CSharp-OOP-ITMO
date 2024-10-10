using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Entities;

public class Train
{
    private readonly Weight _weight;
    private readonly Strength _maxStrength;
    private readonly Time _accuracy;
    private Speed _speed;
    private Acceleration _acceleration;

    public Train(double weight, double maxStrength, double accuracy)
    {
        _weight = new Weight(weight);
        _maxStrength = new Strength(maxStrength);
        _accuracy = new Time(accuracy);
        _speed = new Speed(0);
        _acceleration = new Acceleration(0);
    }

    public ApplyForceResult ApplyForce(Strength strengthValue)
    {
        if (strengthValue > _maxStrength)
            return new ApplyForceResult.Failure();

        _acceleration = strengthValue / _weight;

        return new ApplyForceResult.Success();
    }

    public PassDistanceResult PassDistance(Distance distance)
    {
        if (_speed <= new Speed(0) && _acceleration <= new Acceleration(0))
            return new PassDistanceResult.Failure();

        var distanceTraveled = new Distance(0);
        var passingTime = new Time(0);

        while (distanceTraveled < distance)
        {
            passingTime += _accuracy;
            _speed += _acceleration * _accuracy;
            if (_speed < new Speed(0))
                return new PassDistanceResult.Failure();
            distanceTraveled += _speed * _accuracy;
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