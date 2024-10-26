using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;

public class LectureMaterial : ILectureMaterial<LectureMaterial>
{
    public LectureMaterial(
        User author,
        string name,
        Guid id,
        Guid? initialId,
        string description,
        string content)
    {
        Author = author;
        Name = name;
        Id = id;
        InitialId = initialId;
        Description = description;
        Content = content;
    }

    public string Name { get; private set; }

    public string Content { get; private set; }

    public string Description { get; private set; }

    public Guid Id { get; }

    public Guid? InitialId { get; }

    public User Author { get; }

    public SetNameResult SetName(string name, User user)
    {
        if (!user.Equals(Author))
            return new SetNameResult.Failure("User is not author");

        Name = name;

        return new SetNameResult.Success();
    }

    public SetDescriptionResult SetDescription(string description, User user)
    {
        if (!user.Equals(Author))
            return new SetDescriptionResult.Failure("User is not author");

        Description = description;

        return new SetDescriptionResult.Success();
    }

    public SetContextResult SetContext(string context, User user)
    {
        if (!user.Equals(Author))
            return new SetContextResult.Failure("User is not author");

        Content = context;

        return new SetContextResult.Success();
    }

    public LectureMaterial Clone(Guid newId, User newAuthor)
    {
        if (newId.Equals(Id))
            throw new ArgumentException("newId cannot be equal to Id");

        return new LectureMaterial(Author, Name, newId, Id, Description, Content);
    }
}