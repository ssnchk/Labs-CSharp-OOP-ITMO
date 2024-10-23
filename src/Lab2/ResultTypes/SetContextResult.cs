namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record class SetContextResult
{
    public sealed record Success : SetContextResult;

    public sealed record Failure(string Message) : SetContextResult;
}