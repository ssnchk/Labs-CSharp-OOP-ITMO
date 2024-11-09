using Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms.Semesters;
using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms;

public interface IEducationalProgram : IIdentifiable
{
    public User Supervisor { get; }

    public IReadOnlyCollection<ISemester> Semesters { get; }
}