using Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Models;
using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Entities;

public class PowerMagneticRoad : IRouteSection
{
    private readonly Distance _distance;
    private readonly Strength _appliedForce;

    public PowerMagneticRoad(double distance, double appliedForce)
    {
        _distance = new Distance(distance);
        _appliedForce = new Strength(appliedForce);
    }

    public PassRouteSectionResult PassResult(TrainInfo.Entities.Train train)
    {
        if (train.ApplyForce(_appliedForce) is ApplyForceResult.Failure applyForceResult)
            return new PassRouteSectionResult.Failure(applyForceResult);

        PassDistanceResult passDistanceResult = train.PassDistance(_distance);

        if (passDistanceResult is PassDistanceResult.Failure passDistanceResultFailure)
            return new PassRouteSectionResult.Failure(passDistanceResultFailure);

        train.ApplyForce(new Strength(0));

        return new PassRouteSectionResult.Success(((PassDistanceResult.Success)passDistanceResult).RideTime);
    }
}