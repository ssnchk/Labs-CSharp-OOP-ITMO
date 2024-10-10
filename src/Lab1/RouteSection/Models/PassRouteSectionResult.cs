using Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;
using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.RouteSection.Models;

public abstract record class PassRouteSectionResult
{
    private PassRouteSectionResult() { }

    public sealed record Success(Time RideTime) : PassRouteSectionResult;

    public sealed record Failure(ITrainActionResult Result) : PassRouteSectionResult;
}