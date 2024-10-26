using Itmo.ObjectOrientedProgramming.Lab2.IdGenerators;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.LectureMaterials;

public class LectureMaterial : ILectureMaterial<LectureMaterial>
{
    private LectureMaterial(
        User currentUser,
        User author,
        string name,
        long id,
        long? initialId,
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

    public string Name { get; }

    public string Content { get; }

    public string Description { get; }

    public long Id { get; }

    public long? ParentId { get; }

    public User Author { get; }

    public User CurrentUser { get; private set; }

    public void SetCurrentUser(User user)
    {
        CurrentUser = user;
    }

    public UpdateLectureMaterealResult Update(string name, string description, string content)
    {
        if (CurrentUser != Author)
            return new UpdateLectureMaterealResult.Failure("Only author can update");

        return new UpdateLectureMaterealResult.Success(new LectureMaterial(
            CurrentUser,
            Author,
            name,
            Id,
            ParentId,
            description,
            content));
    }

    public LectureMaterial Clone()
    {
        return new LectureMaterial(CurrentUser, CurrentUser, Name, IdGenerator.GenerateNewId(), Id, Description, Content);
    }

    public LectureMaterialBuilder Direct(LectureMaterialBuilder builder)
    {
        builder
            .WithName(Name)
            .WithParentId(Id)
            .WithDescription(Description)
            .WithContent(Content)
            .WithAuthor(CurrentUser);

        return builder;
    }

    public class LectureMaterialBuilder
    {
        private string? _content;
        private string? _name;
        private string? _description;

        private long? _parentId;

        private User? _author;
        private User? _currentUser;

        public LectureMaterialBuilder WithParentId(long? id)
        {
            _parentId = id;
            return this;
        }

        public LectureMaterialBuilder WithCurrentUser(User currentUser)
        {
            _currentUser = currentUser;
            return this;
        }

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

        public LectureMaterialBuilder WithContent(string content)
        {
            _content = content;
            return this;
        }

        public ILectureMaterial Build()
        {
            return new LectureMaterial(
                _currentUser ?? throw new ArgumentNullException(nameof(_currentUser)),
                _author ?? throw new ArgumentNullException(nameof(_author)),
                _name ?? throw new ArgumentNullException(nameof(_name)),
                IdGenerator.GenerateNewId(),
                _parentId,
                _description ?? throw new ArgumentNullException(nameof(_description)),
                _content ?? throw new ArgumentNullException(nameof(_content)));
        }
    }
}