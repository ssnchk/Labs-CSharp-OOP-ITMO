using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Builders;

public class ExamSubjectBuilder : ISubjectsBuilder
{
    private readonly Guid? _initialId = null;

    private readonly List<ILaboratoryWork> _laboratoryWorks = [];

    private readonly List<ILectureMaterial> _lectureMaterials = [];

    private Points? _examPoints;

    private string? _name;

    private User? _author;

    private Guid? _id;

    public ISubjectsBuilder WithPoints(Points? examPoints)
    {
        _examPoints = examPoints;
        return this;
    }

    public ISubjectsBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ISubjectsBuilder WithId(Guid id)
    {
        _id = id;
        return this;
    }

    public ISubjectsBuilder WithAuthor(User author)
    {
        _author = author;
        return this;
    }

    public ISubjectsBuilder AddLaboratoryWork(ILaboratoryWork laboratoryWork)
    {
        _laboratoryWorks.Add(laboratoryWork);
        return this;
    }

    public ISubjectsBuilder AddLectureMaterial(ILectureMaterial lectureMaterial)
    {
        _lectureMaterials.Add(lectureMaterial);
        return this;
    }

    public ISubject Build()
    {
        if (_laboratoryWorks.Sum(laboratoryWork => laboratoryWork.PointsAmount.Value) != ISubject.MaxSubjectPoints().Value)
            throw new ArgumentException("Sum of points of laboratory works is not equal to exam points.");

        return new ExamSubject(
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _id ?? throw new ArgumentNullException(nameof(_id)),
            _initialId,
            _laboratoryWorks,
            _lectureMaterials,
            _examPoints ?? throw new ArgumentNullException(nameof(_examPoints)),
            _author ?? throw new ArgumentNullException(nameof(_author)));
    }
}