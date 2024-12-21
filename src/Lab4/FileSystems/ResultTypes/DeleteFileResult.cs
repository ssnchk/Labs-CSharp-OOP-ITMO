namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.ResultTypes;

public abstract record DeleteFileResult
{
    public sealed record Success : DeleteFileResult;

    public sealed record Failure : DeleteFileResult;
}