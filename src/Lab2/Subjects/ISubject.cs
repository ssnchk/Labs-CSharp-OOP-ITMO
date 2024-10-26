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

    public Guid Id { get; }

    public Guid? ParentId { get; }

    public SetNameResult SetName(string name, User user);
}

public interface ISubject<out T> : ISubject
    where T : ISubject<T>
{
    public T Clone(Guid newId, User newAuthor);
}