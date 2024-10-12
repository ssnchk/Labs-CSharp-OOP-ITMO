using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteInfo.Models;

public abstract record class PassRouteResult
{
    private PassRouteResult() { }

    public sealed record Success(TimeSpan RideTime) : PassRouteResult;

    public sealed record Failure(ITrainActionResult TrainActionResult) : PassRouteResult;
}