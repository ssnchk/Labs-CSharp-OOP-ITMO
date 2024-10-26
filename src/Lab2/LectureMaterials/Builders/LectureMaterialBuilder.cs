using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials.Builders;

public class LectureMaterialBuilder
{
    private readonly Guid? _parentId = null;

    private string? _content;
    private string? _name;
    private string? _description;

    private Guid? _id;
    private User? _author;

    public LectureMaterialBuilder WithAuthor(User author)
    {
        _author = author;
        return this;
    }

    public LectureMaterialBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public LectureMaterialBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public LectureMaterialBuilder WithId(Guid id)
    {
        _id = id;
        return this;
    }

    public LectureMaterialBuilder WithContext(string context)
    {
        _content = context;
        return this;
    }

    public ILectureMaterial Build()
    {
        return new LectureMaterial(
            _author ?? throw new ArgumentNullException(nameof(_author)),
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _id ?? throw new ArgumentNullException(nameof(_id)),
            _parentId,
            _description ?? throw new ArgumentNullException(nameof(_description)),
            _content ?? throw new ArgumentNullException(nameof(_content)));
    }
}