using Itmo.ObjectOrientedProgramming.Lab2.IdGenerators;
using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Builders;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class ExamSubject : ISubject<ExamSubject>
{
    public static Points MaxSubjectPoints()
        => new Points(100);

    private ExamSubject(
        User currentUser,
        string name,
        long id,
        long? parentId,
        IReadOnlyCollection<ILaboratoryWork> laboratoryWorks,
        IReadOnlyCollection<ILectureMaterial> lectureMaterials,
        Points examPoints,
        User author)
    {
        if ((laboratoryWorks.Sum(laboratoryWork => laboratoryWork.PointsAmount.Value) + examPoints.Value) !=
            MaxSubjectPoints().Value)
        {
            throw new ArgumentException("Sum of points of laboratory works is not equal to exam points.");
        }

        CurrentUser = currentUser;
        Name = name;
        LaboratoryWorks = laboratoryWorks;
        LectureMaterials = lectureMaterials;
        Author = author;
        Id = id;
        ParentId = parentId;
        ExamPoints = examPoints;
    }

    public string Name { get; }

    public IReadOnlyCollection<ILaboratoryWork> LaboratoryWorks { get; }

    public IReadOnlyCollection<ILectureMaterial> LectureMaterials { get; }

    public User Author { get; }

    public User CurrentUser { get; private set; }

    public long Id { get; }

    public long? ParentId { get; }

    public Points ExamPoints { get; }

    public void SetCurrentUser(User user)
    {
        CurrentUser = user;
    }

    public UpdateSubjectResult Update(string name)
    {
        if (CurrentUser != Author)
            return new UpdateSubjectResult.Failure("User is not author");

        var updatedExamSubject = new ExamSubject(
            Author,
            name,
            Id,
            ParentId,
            LaboratoryWorks,
            LectureMaterials,
            ExamPoints,
            Author);

        return new UpdateSubjectResult.Success(updatedExamSubject);
    }

    public ExamSubject Clone()
    {
        return new ExamSubject(
            CurrentUser,
            Name,
            IdGenerator.GenerateNewId(),
            Id,
            LaboratoryWorks,
            LectureMaterials,
            ExamPoints,
            CurrentUser);
    }

    public class ExamSubjectBuilder(Points examPoints) : ISubjectsBuilder
    {
        private readonly long? _parentId = null;
        private readonly List<ILaboratoryWork> _laboratoryWorks = [];
        private readonly List<ILectureMaterial> _lectureMaterials = [];

        private string? _name;
        private User? _author;
        private User? _currentUser;

        public ISubjectsBuilder WithCurrentUser(User user)
        {
            _currentUser = user;
            return this;
        }

        public ISubjectsBuilder WithName(string name)
        {
            _name = name;
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
            return new ExamSubject(
                _currentUser ?? throw new ArgumentNullException(nameof(_currentUser)),
                _name ?? throw new ArgumentNullException(nameof(_name)),
                IdGenerator.GenerateNewId(),
                _parentId,
                _laboratoryWorks,
                _lectureMaterials,
                examPoints ?? throw new ArgumentNullException(nameof(examPoints)),
                _author ?? throw new ArgumentNullException(nameof(_author)));
        }
    }
}