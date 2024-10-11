using Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Models;
using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Entities;

public class MagneticRoad : IRouteSection
{
    private readonly Distance _distance;

    public MagneticRoad(Distance distance)
    {
        _distance = distance;
    }

    public PassRouteSectionResult PassResult(TrainInfo.Entities.Train train)
    {
        PassDistanceResult passDistanceResult = train.PassDistance(_distance);

        if (passDistanceResult is PassDistanceResult.Success passDistanceResultSuccess)
            return new PassRouteSectionResult.Success(passDistanceResultSuccess.RideTime);

        return new PassRouteSectionResult.Failure(new PassDistanceResult.Failure());
    }
}