namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems.ResultTypes;

public abstract record RenameFileResult
{
    public sealed record Success : RenameFileResult;

    public sealed record Failure : RenameFileResult;
}