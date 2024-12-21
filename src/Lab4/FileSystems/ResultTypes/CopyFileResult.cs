namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.ResultTypes;

public abstract record CopyFileResult
{
    public sealed record Success : CopyFileResult;

    public sealed record Failure : CopyFileResult;
}