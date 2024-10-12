namespace Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;

public abstract record PassDistanceResult : ITrainActionResult
{
    public sealed record Success(TimeSpan RideTime) : PassDistanceResult;

    public sealed record Failure : PassDistanceResult;
}