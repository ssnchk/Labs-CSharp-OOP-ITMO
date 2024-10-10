using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteInfo.Models;

public abstract record class PassRouteResult
{
    private PassRouteResult() { }

    public sealed record Success(Time RideTime) : PassRouteResult;

    public sealed record Failure(ITrainActionResult FailureResult) : PassRouteResult;
}