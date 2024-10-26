using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Builders;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Factories;

public interface ISubjectBuilderFactory
{
    ISubjectsBuilder Create();
}