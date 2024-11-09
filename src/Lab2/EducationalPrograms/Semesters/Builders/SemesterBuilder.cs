using Itmo.ObjectOrientedProgramming.Lab2.Subjects;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms.Semesters.Builders;

public class SemesterBuilder
{
    private readonly List<ISubject> _subjects = [];

    private SemesterNumber? _number;

    public SemesterBuilder WithNumber(SemesterNumber number)
    {
        _number = number;
        return this;
    }

    public SemesterBuilder AddSubject(ISubject subjects)
    {
        _subjects.Add(subjects);
        return this;
    }

    public ISemester Build()
    {
        return new Semester(
            _number ?? throw new ArgumentNullException(nameof(_number)),
            _subjects);
    }
}