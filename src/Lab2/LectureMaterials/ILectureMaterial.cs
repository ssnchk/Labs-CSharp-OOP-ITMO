using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;

public interface ILectureMaterial : IWithAuthor, IWithId, IWithInitialId, IWithDescription, IWithContent, IWithName
{
    public SetNameResult SetName(string name, User user);

    public SetDescriptionResult SetDescription(string description, User user);

    public SetContextResult SetContext(string context, User user);
}

public interface ILectureMaterial<out T> : ILectureMaterial
    where T : ILectureMaterial<T>
{
    public T Clone(Guid newId, User newAuthor);
}