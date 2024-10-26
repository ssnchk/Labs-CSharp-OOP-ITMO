using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;

public class LectureMaterial : ILectureMaterial<LectureMaterial>
{
    public LectureMaterial(
        User currentUser,
        User author,
        string name,
        Guid id,
        Guid? initialId,
        string description,
        string content)
    {
        CurrentUser = currentUser;
        Author = author;
        Name = name;
        Id = id;
        ParentId = initialId;
        Description = description;
        Content = content;
    }

    public string Name { get; private set; }

    public string Content { get; private set; }

    public string Description { get; private set; }

    public Guid Id { get; }

    public Guid? ParentId { get; }

    public User Author { get; }

    public User CurrentUser { get; private set; }

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

    public SetDescriptionResult SetDescription(string description)
    {
        if (!CurrentUser.Equals(Author))
            return new SetDescriptionResult.Failure("User is not author");

        Description = description;

        return new SetDescriptionResult.Success();
    }

    public SetContextResult SetContext(string context)
    {
        if (!CurrentUser.Equals(Author))
            return new SetContextResult.Failure("User is not author");

        Content = context;

        return new SetContextResult.Success();
    }

    public LectureMaterial Clone(Guid newId)
    {
        if (newId.Equals(Id))
            throw new ArgumentException("newId cannot be equal to Id");

        return new LectureMaterial(CurrentUser, CurrentUser, Name, newId, Id, Description, Content);
    }
}