namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories.ResultTypes;

public abstract record class RemoveItemResult
{
    public sealed record Success : RemoveItemResult;

    public sealed record Failure(string Message) : RemoveItemResult;
}
