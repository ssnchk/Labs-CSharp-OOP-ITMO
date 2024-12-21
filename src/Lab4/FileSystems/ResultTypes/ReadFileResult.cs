namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.ResultTypes;

public abstract record ReadFileResult
{
    public sealed record Success(string Content) : ReadFileResult;

    public sealed record Failure : ReadFileResult;
}