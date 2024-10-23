namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record class SetCriteriasResult
{
    public sealed record Success : SetCriteriasResult;

    public sealed record Failure(string Message) : SetCriteriasResult;
}