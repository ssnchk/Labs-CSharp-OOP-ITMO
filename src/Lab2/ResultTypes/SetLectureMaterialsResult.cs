namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record SetLectureMaterialsResult()
{
    public sealed record Success() : SetLectureMaterialsResult();

    public sealed record Failure(string Message) : SetLectureMaterialsResult();
}