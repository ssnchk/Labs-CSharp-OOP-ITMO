using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IWithLectureMaterials
{
    public IReadOnlyCollection<ILectureMaterial> LectureMaterials { get; }
}