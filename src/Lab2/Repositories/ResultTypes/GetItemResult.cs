namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories.ResultTypes;

public abstract record class GetItemResult<T>
{
    public sealed record Success(T Item) : GetItemResult<T>;

    public sealed record Failure(string Message) : GetItemResult<T>;
}
