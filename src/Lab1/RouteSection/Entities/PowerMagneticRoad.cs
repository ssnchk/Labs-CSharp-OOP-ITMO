using Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Models;
using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Entities;

public class PowerMagneticRoad : IRouteSection
{
    private readonly Distance _distance;
    private readonly Strength _appliedForce;

    public PowerMagneticRoad(Distance distance, Strength appliedForce)
    {
        _distance = distance;
        _appliedForce = appliedForce;
    }

    public PassRouteSectionResult PassResult(TrainInfo.Entities.Train train)
    {
        if (train.ApplyForce(_appliedForce) is ApplyForceResult.Failure applyForceResult)
            return new PassRouteSectionResult.Failure(applyForceResult);

        PassDistanceResult passDistanceResult = train.PassDistance(_distance);

        if (passDistanceResult is not PassDistanceResult.Success passDistanceResultSuccess)
            return new PassRouteSectionResult.Failure(new PassDistanceResult.Failure());

        train.ApplyForce(Strength.Zero);

        return new PassRouteSectionResult.Success(passDistanceResultSuccess.RideTime);
    }
}