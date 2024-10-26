using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class TestSubject : ISubject<TestSubject>
{
    public static Points MaxSubjectPoints()
        => new Points(100);

    public TestSubject(
        User currentUser,
        string name,
        Guid id,
        Guid? parentId,
        IReadOnlyCollection<ILaboratoryWork> laboratoryWorks,
        IReadOnlyCollection<ILectureMaterial> lectureMaterials,
        Points minSuccessPoints,
        User author)
    {
        if (laboratoryWorks.Sum(laboratoryWork => laboratoryWork.PointsAmount.Value) != MaxSubjectPoints().Value)
            throw new ArgumentException("Sum of points of laboratory works is not equal to exam points.");

        CurrentUser = currentUser;
        Name = name;
        LaboratoryWorks = laboratoryWorks;
        LectureMaterials = lectureMaterials;
        Author = author;
        Id = id;
        MinSuccessPoints = minSuccessPoints;
        ParentId = parentId;
    }

    public string Name { get; private set; }

    public IReadOnlyCollection<ILaboratoryWork> LaboratoryWorks { get; }

    public IReadOnlyCollection<ILectureMaterial> LectureMaterials { get; }

    public Points MinSuccessPoints { get; }

    public User Author { get; }

    public User CurrentUser { get; private set; }

    public Guid Id { get; }

    public Guid? ParentId { get; }

    public void SetCurrentUser(User user)
    {
        CurrentUser = user;
    }

    public SetNameResult SetName(string name)
    {
        if (!CurrentUser.Equals(Author))
            return new SetNameResult.Failure("User is not author");

        Name = name;

        return new SetNameResult.Success();
    }

    public TestSubject Clone(Guid newId)
    {
        if (newId.Equals(Id))
            throw new ArgumentException("newId cannot be equal to Id");

        return new TestSubject(CurrentUser, Name, newId, Id, LaboratoryWorks, LectureMaterials, MinSuccessPoints, CurrentUser);
    }
}