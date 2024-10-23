using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms.Semesters.Builders;

public interface ISemesterBuilder
{
    public ISemesterBuilder WithNumber(SemesterNumber number);

    public ISemesterBuilder WithSubjects(IReadOnlyCollection<ISubject> subjects);

    public ISemester Build();
}