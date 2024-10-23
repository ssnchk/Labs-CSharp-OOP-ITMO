using Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms.Semesters;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms.Builders;

public class EducationalProgramBuilder : IEducationalProgramBuilder
{
    private readonly List<ISemester> _semesters = [];

    private User? _supervisor;
    private Guid? _id;

    public IEducationalProgramBuilder WithSupervisor(User supervisor)
    {
        _supervisor = supervisor;
        return this;
    }

    public IEducationalProgramBuilder WithId(Guid id)
    {
        _id = id;
        return this;
    }

    public IEducationalProgramBuilder AddSemester(ISemester semester)
    {
        if (semester.Number.Value != _semesters.Count + 1)
            throw new ArgumentException("Semester number must be consecutive");

        _semesters.Add(semester);

        return this;
    }

    public IEducationalProgram Build()
    {
        return new EducationalProgram(
            _supervisor ?? throw new ArgumentNullException(nameof(_supervisor)),
            _id ?? throw new ArgumentNullException(nameof(_id)),
            _semesters);
    }
}