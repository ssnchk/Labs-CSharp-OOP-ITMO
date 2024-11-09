using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;

public interface ILectureMaterial : ILectureMaterialBuilderDirector
{
    public string Name { get; }

    public string Content { get; }

    public string Description { get; }

    public long Id { get; }

    public long? ParentId { get; }

    public User Author { get; }

    public User CurrentUser { get; }

    void SetCurrentUser(User user);

    UpdateLectureMaterealResult Update(string name, string description, string content);
}

public interface ILectureMaterial<out T> : ILectureMaterial
    where T : ILectureMaterial<T>
{
    T Clone();
}