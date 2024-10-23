using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public interface ISubject : IWithAuthor, IWithId, IWithInitialId, IWithLaboratoryWorks, IWithLectureMaterials, IWithName
{
    public static Points MaxSubjectPoints() => new Points(100);

    public SetNameResult SetName(string name, User user);
}

public interface ISubject<out T> : ISubject
    where T : ISubject<T>
{
    public T Clone(Guid newId, User newAuthor);
}