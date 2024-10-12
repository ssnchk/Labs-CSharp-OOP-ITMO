using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Models;

public abstract record class PassRouteSectionResult
{
    private PassRouteSectionResult() { }

    public sealed record Success(TimeSpan RideTime) : PassRouteSectionResult;

    public sealed record Failure(ITrainActionResult Result) : PassRouteSectionResult;
}