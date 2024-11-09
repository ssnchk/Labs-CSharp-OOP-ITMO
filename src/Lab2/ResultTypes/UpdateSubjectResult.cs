using Itmo.ObjectOrientedProgramming.Lab2.Subjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record UpdateSubjectResult()
{
    public sealed record Success(ISubject Result) : UpdateSubjectResult;

    public sealed record Failure(string Message) : UpdateSubjectResult;
}