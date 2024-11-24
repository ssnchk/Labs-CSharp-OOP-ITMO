namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.ResultTypes;

public abstract record MoveFileResult
{
    public sealed record Success : MoveFileResult;

    public sealed record Failure : MoveFileResult;
}