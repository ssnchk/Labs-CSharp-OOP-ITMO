using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks.Builders;

public class LaboratoryWorkBuilder
{
    private readonly Guid? _parentId = null;
    private readonly List<string> _criteria = [];

    private string? _name;
    private string? _description;

    private Guid? _id;
    private Points? _pointsAmount;
    private User? _author;
    private User? _currentUser;

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

    public LaboratoryWorkBuilder WithId(Guid id)
    {
        _id = id;
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
            _id ?? throw new ArgumentNullException(nameof(_id)),
            _parentId,
            _pointsAmount ?? throw new ArgumentNullException(nameof(_pointsAmount)),
            _description ?? throw new ArgumentNullException(nameof(_description)),
            _criteria);
    }
}