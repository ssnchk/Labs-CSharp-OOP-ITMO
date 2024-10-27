namespace Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks;

public interface ILaboratoryWorkBuilderDirector
{
    LaboratoryWork.LaboratoryWorkBuilder Direct(LaboratoryWork.LaboratoryWorkBuilder builder);
}