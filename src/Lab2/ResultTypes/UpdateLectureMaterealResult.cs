using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;

namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record UpdateLectureMaterealResult
{
    public sealed record Success(ILectureMaterial Result) : UpdateLectureMaterealResult;

    public sealed record Failure(string Message) : UpdateLectureMaterealResult;
}