using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Factories;

public class ExamSubjectBuilderFactory : ISubjectBuilderFactory
{
    public ISubjectsBuilder Create()
    {
        return new ExamSubjectBuilder();
    }
}