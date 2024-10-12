using Itmo.ObjectOrientedProgramming.Lab1.RouteInfo.Models;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Models;
using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteInfo.Entities;

public class Route
{
    private readonly IReadOnlyCollection<IRouteSection> _sections;
    private readonly Speed _maxBreakSpeed;

    public Route(IReadOnlyCollection<IRouteSection> sections, Speed maxBreakSpeed)
    {
        _sections = sections;
        _maxBreakSpeed = maxBreakSpeed;
    }

    public PassRouteResult PassRoute(Train train)
    {
        var rideTime = new TimeSpan(0);
        foreach (IRouteSection section in _sections)
        {
            PassRouteSectionResult passingSectionResult = section.PassResult(train);

            if (passingSectionResult is PassRouteSectionResult.Failure passRouteSectionFailure)
                return new PassRouteResult.Failure(passRouteSectionFailure.Result);

            if (passingSectionResult is PassRouteSectionResult.Success passRouteSectionSuccess)
                rideTime += passRouteSectionSuccess.RideTime;
        }

        StopTrainResult stopTrainResult = train.StopTrain(_maxBreakSpeed);
        if (stopTrainResult is not StopTrainResult.Success)
            return new PassRouteResult.Failure(stopTrainResult);

        return new PassRouteResult.Success(rideTime);
    }
}