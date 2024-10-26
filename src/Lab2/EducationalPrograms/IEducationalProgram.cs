using Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms.Semesters;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms;

public interface IEducationalProgram
{
    public User Supervisor { get; }

    public Guid Id { get; }

    public IReadOnlyCollection<ISemester> Semesters { get; }
}