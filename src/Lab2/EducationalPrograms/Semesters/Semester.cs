using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms.Semesters;

public class Semester : ISemester
{
    public SemesterNumber Number { get; }

    public IReadOnlyCollection<ISubject> Subjects { get; }

    public Semester(SemesterNumber number, IReadOnlyCollection<ISubject> subjects)
    {
        Number = number;
        Subjects = subjects;
    }
}