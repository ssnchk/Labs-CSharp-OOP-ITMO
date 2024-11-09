namespace Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

public abstract record MarkAsReadResult
{
    public sealed record Success : MarkAsReadResult;

    public sealed record Failure(string Message) : MarkAsReadResult;
}