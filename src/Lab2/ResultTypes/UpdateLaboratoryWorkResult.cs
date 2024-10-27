using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks;

namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record UpdateLaboratoryWorkResult
{
    public sealed record Success(ILaboratoryWork Result) : UpdateLaboratoryWorkResult;

    public sealed record Failure(string Message) : UpdateLaboratoryWorkResult;
}