using Itmo.ObjectOrientedProgramming.Lab1.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;

public abstract record PassDistanceResult : ITrainActionResult
{
    public sealed record Success(Time RideTime) : PassDistanceResult;

    public sealed record Failure : PassDistanceResult;
}