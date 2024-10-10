using Itmo.ObjectOrientedProgramming.Lab1.RouteInfo.Models;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Models;
using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteInfo.Entities;

public class Route
{
    private readonly IReadOnlyCollection<IRouteSection> _sections;
    private readonly Speed _maxBreakSpeed;

    public Route(IReadOnlyCollection<IRouteSection> sections, double maxBreakSpeed)
    {
        _sections = sections;
        _maxBreakSpeed = new Speed(maxBreakSpeed);
    }

    public PassRouteResult PassRoute(TrainInfo.Entities.Train train)
    {
        var rideTime = new Time(0);
        foreach (IRouteSection section in _sections)
        {
            PassRouteSectionResult passingSectionResult = section.PassResult(train);
            if (passingSectionResult is PassRouteSectionResult.Failure passRouteSectionResult)
                return new PassRouteResult.Failure(passRouteSectionResult.Result);

            rideTime += ((PassRouteSectionResult.Success)passingSectionResult).RideTime;
        }

        StopTrainResult stopTrainResult = train.StopTrain(_maxBreakSpeed);
        if (stopTrainResult is not StopTrainResult.Success)
            return new PassRouteResult.Failure(stopTrainResult);

        return new PassRouteResult.Success(rideTime);
    }
}