namespace Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;

public interface ILectureMaterialBuilderDirector
{
    LectureMaterial.LectureMaterialBuilder Direct(LectureMaterial.LectureMaterialBuilder builder);
}