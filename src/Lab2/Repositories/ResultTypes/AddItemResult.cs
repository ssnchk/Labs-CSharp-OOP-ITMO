namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories.ResultTypes;

public abstract record class AddItemResult
{
    public sealed record Success : AddItemResult;

    public sealed record Failure(string Message) : AddItemResult;
}
