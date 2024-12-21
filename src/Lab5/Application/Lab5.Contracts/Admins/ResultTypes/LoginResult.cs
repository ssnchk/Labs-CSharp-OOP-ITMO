namespace Lab5.Contracts.Admins.ResultTypes;

public abstract record LoginResult
{
    public sealed record Success : LoginResult;

    public sealed record Failure(string Message) : LoginResult;
}