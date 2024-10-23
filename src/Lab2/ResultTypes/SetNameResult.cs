namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record class SetNameResult
{
    public sealed record Success : SetNameResult;

    public sealed record Failure(string Message) : SetNameResult;
}