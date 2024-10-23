using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms.Semesters.Builders;

public class SemesterBuilder : ISemesterBuilder
{
    private SemesterNumber? _number;

    private IReadOnlyCollection<ISubject>? _subjects;

    public ISemesterBuilder WithNumber(SemesterNumber number)
    {
        _number = number;
        return this;
    }

    public ISemesterBuilder WithSubjects(IReadOnlyCollection<ISubject> subjects)
    {
        _subjects = subjects;
        return this;
    }

    public ISemester Build()
    {
        return new Semester(
            _number ?? throw new ArgumentNullException(nameof(_number)),
            _subjects ?? throw new ArgumentNullException(nameof(_subjects)));
    }
}