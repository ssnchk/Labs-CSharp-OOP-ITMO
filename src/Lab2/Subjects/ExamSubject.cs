using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class ExamSubject : ISubject<ExamSubject>
{
    public static Points MaxSubjectPoints()
        => new Points(100);

    public ExamSubject(
        string name,
        Guid id,
        Guid? parentId,
        IReadOnlyCollection<ILaboratoryWork> laboratoryWorks,
        IReadOnlyCollection<ILectureMaterial> lectureMaterials,
        Points examPoints,
        User author)
    {
        if (laboratoryWorks.Sum(laboratoryWork => laboratoryWork.PointsAmount.Value) != MaxSubjectPoints().Value)
            throw new ArgumentException("Sum of points of laboratory works is not equal to exam points.");

        Name = name;
        LaboratoryWorks = laboratoryWorks;
        LectureMaterials = lectureMaterials;
        Author = author;
        Id = id;
        ParentId = parentId;
        ExamPoints = examPoints;
    }

    public string Name { get; private set; }

    public IReadOnlyCollection<ILaboratoryWork> LaboratoryWorks { get; }

    public IReadOnlyCollection<ILectureMaterial> LectureMaterials { get; }

    public User Author { get; }

    public Guid Id { get; }

    public Guid? ParentId { get; }

    public Points ExamPoints { get; }

    public SetNameResult SetName(string name, User user)
    {
        if (!user.Equals(Author))
            return new SetNameResult.Failure("User is not author");

        Name = name;

        return new SetNameResult.Success();
    }

    public ExamSubject Clone(Guid newId, User newAuthor)
    {
        if (newId.Equals(Id))
            throw new ArgumentException("newId cannot be equal to Id");

        return new ExamSubject(Name, newId, Id, LaboratoryWorks, LectureMaterials, ExamPoints, newAuthor);
    }
}