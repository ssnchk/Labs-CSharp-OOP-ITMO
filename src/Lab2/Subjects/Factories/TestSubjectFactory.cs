using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Factories;

public class TestSubjectFactory : ISubjectFactory
{
    public ISubjectsBuilder Create()
    {
        return new TestSubjectBuilder();
    }
}