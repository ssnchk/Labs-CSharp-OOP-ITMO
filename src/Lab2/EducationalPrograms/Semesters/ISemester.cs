using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms.Semesters;

public interface ISemester
{
    public SemesterNumber Number { get; }

    public IReadOnlyCollection<ISubject> Subjects { get; }
}