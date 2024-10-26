using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Factories;

public class TestSubjectBuilderFactory : ISubjectBuilderFactory
{
    public ISubjectsBuilder Create()
    {
        return new TestSubjectBuilder();
    }
}