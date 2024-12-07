namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Admins.ResultTypes;

public abstract record ChangePasswordResult
{
    public sealed record Success : ChangePasswordResult;

    public sealed record Failure(string Message) : ChangePasswordResult;
}