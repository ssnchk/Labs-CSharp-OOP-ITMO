using Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms.Semesters;
using Itmo.ObjectOrientedProgramming.Lab2.IdGenerators;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationalPrograms;

public class EducationalProgram : IEducationalProgram
{
    private EducationalProgram(User supervisor, long id, IReadOnlyCollection<ISemester> semesters)
    {
        Supervisor = supervisor;
        Id = id;
        Semesters = semesters;
    }

    public User Supervisor { get; }

    public long Id { get; }

    public IReadOnlyCollection<ISemester> Semesters { get; }

    public class EducationalProgramBuilder
    {
        private readonly List<ISemester> _semesters = [];

        private User? _supervisor;

        public EducationalProgramBuilder WithSupervisor(User supervisor)
        {
            _supervisor = supervisor;
            return this;
        }

        public EducationalProgramBuilder AddSemester(ISemester semester)
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
                IdGenerator.GenerateNewId(),
                _semesters);
        }
    }
}