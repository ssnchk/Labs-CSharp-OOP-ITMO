namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.ResultTypes;

public abstract record ChangeDirectoryResult
{
    public sealed record Success : ChangeDirectoryResult;

    public sealed record Failure : ChangeDirectoryResult;
}