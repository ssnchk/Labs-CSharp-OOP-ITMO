using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks;
using Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public interface ISubject
{
    public string Name { get; }

    public IReadOnlyCollection<ILaboratoryWork> LaboratoryWorks { get; }

    public IReadOnlyCollection<ILectureMaterial> LectureMaterials { get; }

    public User Author { get; }

    public User CurrentUser { get; }

    public Guid Id { get; }

    public Guid? ParentId { get; }

    public void SetCurrentUser(User user);

    public SetNameResult SetName(string name);
}

public interface ISubject<out T> : ISubject
    where T : ISubject<T>
{
    public T Clone(Guid newId);
}