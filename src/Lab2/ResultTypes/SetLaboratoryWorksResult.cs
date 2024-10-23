namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record SetLaboratoryWorksResult()
{
    public sealed record Success() : SetLaboratoryWorksResult();

    public sealed record Failure(string Message) : SetLaboratoryWorksResult();
}