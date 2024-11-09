using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;

namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public class LectureMaterialUpdateResult
{
    public sealed record Success(ILectureMaterial Result) : UpdateLaboratoryWorkResult;

    public sealed record Failure(string Message) : UpdateLaboratoryWorkResult;
}