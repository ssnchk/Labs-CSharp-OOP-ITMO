namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.ResultTypes;

public abstract record ExecuteCommandResult
{
    public sealed record Success : ExecuteCommandResult;

    public sealed record Failure : ExecuteCommandResult;
}