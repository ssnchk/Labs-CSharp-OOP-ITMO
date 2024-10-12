namespace Itmo.ObjectOrientedProgramming.Lab1.TrainInfo.Models;

public abstract record class StopTrainResult : ITrainActionResult
{
    public sealed record Success : StopTrainResult;

    public sealed record Failure : StopTrainResult;
}