namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record class SetDescriptionResult
{
    public sealed record Success : SetDescriptionResult;

    public sealed record Failure(string Message) : SetDescriptionResult;
}