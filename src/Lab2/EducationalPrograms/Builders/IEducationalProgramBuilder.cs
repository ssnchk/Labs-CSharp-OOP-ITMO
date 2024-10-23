using Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms.Semesters;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms.Builders;

public interface IEducationalProgramBuilder
{
    public IEducationalProgramBuilder WithSupervisor(User supervisor);

    public IEducationalProgramBuilder WithId(Guid id);

    public IEducationalProgramBuilder AddSemester(ISemester semester);

    public IEducationalProgram Build();
}