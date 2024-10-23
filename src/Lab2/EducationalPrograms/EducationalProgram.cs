using Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms.Semesters;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms;

public class EducationalProgram : IEducationalProgram
{
    public User Supervisor { get; }

    public Guid Id { get; }

    public IReadOnlyCollection<ISemester> Semesters { get; }

    public EducationalProgram(User supervisor, Guid id, IReadOnlyCollection<ISemester> semesters)
    {
        Supervisor = supervisor;
        Id = id;
        Semesters = semesters;
    }
}