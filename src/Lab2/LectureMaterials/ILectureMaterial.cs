using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;

public interface ILectureMaterial
{
    public string Name { get; }

    public string Content { get; }

    public string Description { get; }

    public Guid Id { get; }

    public Guid? ParentId { get; }

    public User Author { get; }

    public User CurrentUser { get; }

    void SetCurrentUser(User user);

    SetNameResult SetName(string name);

    SetDescriptionResult SetDescription(string description);

    SetContextResult SetContext(string context);
}

public interface ILectureMaterial<out T> : ILectureMaterial
    where T : ILectureMaterial<T>
{
    T Clone(Guid newId);
}