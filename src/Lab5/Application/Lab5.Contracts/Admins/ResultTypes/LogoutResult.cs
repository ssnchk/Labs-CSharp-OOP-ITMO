namespace Lab5.Contracts.Admins.ResultTypes;

public abstract record LogoutResult
{
    public sealed record Success : LogoutResult;

    public sealed record Failure(string Message) : LogoutResult;
}