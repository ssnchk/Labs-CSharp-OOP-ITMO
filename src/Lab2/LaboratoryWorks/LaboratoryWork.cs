using Itmo.ObjectOrientedProgramming.Lab2.IdGenerators;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks;

public class LaboratoryWork : ILaboratoryWork<LaboratoryWork>
{
    private LaboratoryWork(
        User currentUser,
        User author,
        string name,
        long id,
        long? initialId,
        Points pointsAmount,
        string description,
        IReadOnlyCollection<string> criterias)
    {
        CurrentUser = currentUser;
        Author = author;
        Name = name;
        Id = id;
        PointsAmount = pointsAmount;
        Description = description;
        Criterias = criterias;
        ParentId = initialId;
    }

    public long Id { get; }

    public long? ParentId { get; }

    public IReadOnlyCollection<string> Criterias { get; }

    public string Name { get; }

    public string Description { get; }

    public Points PointsAmount { get; }

    public User Author { get; }

    public User CurrentUser { get; private set; }

    public void SetCurrentUser(User user)
    {
        CurrentUser = user;
    }

    public UpdateLaboratoryWorkResult Update(
        string name,
        string description,
        Points pointsAmount,
        IReadOnlyCollection<string> criterias)
    {
        if (CurrentUser != Author)
            return new UpdateLaboratoryWorkResult.Failure("Only author can update");

        return new UpdateLaboratoryWorkResult.Success(new LaboratoryWork(
            CurrentUser,
            CurrentUser,
            name,
            Id,
            Id,
            pointsAmount,
            description,
            criterias));
    }

    public LaboratoryWork Clone()
    {
        return new LaboratoryWork(
            CurrentUser,
            CurrentUser,
            Name,
            IdGenerator.GenerateNewId(),
            Id,
            PointsAmount,
            Description,
            Criterias);
    }

    public LaboratoryWorkBuilder Direct(LaboratoryWorkBuilder builder)
    {
        builder.WithName(Name);
        builder.WithParentId(Id);
        builder.WithDescription(Description);
        builder.WithPointsAmount(PointsAmount);
        builder.WithAuthor(CurrentUser);

        foreach (string criteria in Criterias)
        {
            builder.AddCriteria(criteria);
        }

        return builder;
    }

    public class LaboratoryWorkBuilder
    {
        private readonly List<string> _criteria = [];

        private string? _name;
        private string? _description;

        private long? _parentId;

        private Points? _pointsAmount;
        private User? _author;
        private User? _currentUser;

        public LaboratoryWorkBuilder WithParentId(long? parentId)
        {
            _parentId = parentId;
            return this;
        }

        public LaboratoryWorkBuilder WithCurrentUser(User currentUser)
        {
            _currentUser = currentUser;
            return this;
        }

        public LaboratoryWorkBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public LaboratoryWorkBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public LaboratoryWorkBuilder WithPointsAmount(Points pointsAmount)
        {
            _pointsAmount = pointsAmount;
            return this;
        }

        public LaboratoryWorkBuilder AddCriteria(string criteria)
        {
            _criteria.Add(criteria);
            return this;
        }

        public LaboratoryWorkBuilder WithAuthor(User author)
        {
            _author = author;
            return this;
        }

        public ILaboratoryWork Build()
        {
            return new LaboratoryWork(
                _currentUser ?? throw new ArgumentNullException(nameof(_currentUser)),
                _author ?? throw new ArgumentNullException(nameof(_author)),
                _name ?? throw new ArgumentNullException(nameof(_name)),
                IdGenerator.GenerateNewId(),
                _parentId,
                _pointsAmount ?? throw new ArgumentNullException(nameof(_pointsAmount)),
                _description ?? throw new ArgumentNullException(nameof(_description)),
                _criteria);
        }
    }
}