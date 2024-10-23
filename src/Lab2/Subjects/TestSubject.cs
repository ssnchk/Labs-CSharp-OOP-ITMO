using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class TestSubject : ISubject<TestSubject>
{
    public string Name { get; private set; }

    public IReadOnlyCollection<ILaboratoryWork> LaboratoryWorks { get; }

    public IReadOnlyCollection<ILectureMaterial> LectureMaterials { get; }

    public Points MinSuccessPoints { get; }

    public TestSubject(
        string name,
        Guid id,
        Guid? initialId,
        IReadOnlyCollection<ILaboratoryWork> laboratoryWorks,
        IReadOnlyCollection<ILectureMaterial> lectureMaterials,
        Points minSuccessPoints,
        User author)
    {
        Name = name;
        LaboratoryWorks = laboratoryWorks;
        LectureMaterials = lectureMaterials;
        Author = author;
        Id = id;
        MinSuccessPoints = minSuccessPoints;
        InitialId = initialId;
    }

    public User Author { get; }

    public Guid Id { get; }

    public Guid? InitialId { get; }

    public SetNameResult SetName(string name, User user)
    {
        if (!user.Equals(Author))
            return new SetNameResult.Failure("User is not author");

        Name = name;

        return new SetNameResult.Success();
    }

    public TestSubject Clone(Guid newId, User newAuthor)
    {
        if (newId.Equals(Id))
            throw new ArgumentException("newId cannot be equal to Id");

        return new TestSubject(Name, newId, Id, LaboratoryWorks, LectureMaterials, MinSuccessPoints, newAuthor);
    }
}