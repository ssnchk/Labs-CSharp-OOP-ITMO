using Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Models;
using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Entities;

public class MagneticRoad : IRouteSection
{
    private readonly Distance _distance;

    public MagneticRoad(double distance)
    {
        _distance = new Distance(distance);
    }

    public PassRouteSectionResult PassResult(TrainInfo.Entities.Train train)
    {
        PassDistanceResult passDistanceResult = train.PassDistance(_distance);

        if (passDistanceResult is PassDistanceResult.Failure passDistanceResultFailure)
            return new PassRouteSectionResult.Failure(passDistanceResultFailure);

        return new PassRouteSectionResult.Success(((PassDistanceResult.Success)passDistanceResult).RideTime);
    }
}