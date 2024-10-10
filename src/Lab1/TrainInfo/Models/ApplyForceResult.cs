namespace Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;

public abstract record class ApplyForceResult : ITrainActionResult
{
    public sealed record Success : ApplyForceResult;

    public sealed record Failure : ApplyForceResult;
}
