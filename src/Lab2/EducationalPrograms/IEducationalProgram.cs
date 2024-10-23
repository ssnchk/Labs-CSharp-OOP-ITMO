using Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms.Semesters;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms;

public interface IEducationalProgram : IWithSupervisor, IWithId
{
    public IReadOnlyCollection<ISemester> Semesters { get; }
}