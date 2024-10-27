using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Factories;

public class ExamSubjectBuilderFactory(Points examPoints) : ISubjectBuilderFactory
{
    public ISubjectsBuilder Create()
    {
        return new ExamSubject.ExamSubjectBuilder(examPoints);
    }
}