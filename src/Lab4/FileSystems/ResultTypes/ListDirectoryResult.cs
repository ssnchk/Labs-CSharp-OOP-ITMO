namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.ResultTypes;

public abstract record ListDirectoryResult
{
    public sealed record Success : ListDirectoryResult;

    public sealed record Failure : ListDirectoryResult;
}