using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Factories;

public class TestSubjectBuilderFactory(Points minSuccessPoints) : ISubjectBuilderFactory
{
    public ISubjectsBuilder Create()
    {
        return new TestSubject.TestSubjectBuilder(minSuccessPoints);
    }
}