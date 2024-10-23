using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks.Builders;

public class LaboratoryWorkBuilder : ILaboratoryWorkBuilder
{
    private readonly Guid? _initialId = null;

    private readonly List<string> _criteria = [];
    private string? _name;
    private string? _description;

    private Guid? _id;
    private Points? _pointsAmount;

    private User? _author;

    public ILaboratoryWorkBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ILaboratoryWorkBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public ILaboratoryWorkBuilder WithId(Guid id)
    {
        _id = id;
        return this;
    }

    public ILaboratoryWorkBuilder WithPointsAmount(Points pointsAmount)
    {
        _pointsAmount = pointsAmount;
        return this;
    }

    public ILaboratoryWorkBuilder AddCriteria(string criteria)
    {
        _criteria.Add(criteria);
        return this;
    }

    public ILaboratoryWorkBuilder WithAuthor(User author)
    {
        _author = author;
        return this;
    }

    public ILaboratoryWork Build()
    {
        return new LaboratoryWork(
            _author ?? throw new ArgumentNullException(nameof(_author)),
            _name ?? throw new ArgumentNullException(nameof(_name)),
            _id ?? throw new ArgumentNullException(nameof(_id)),
            _initialId,
            _pointsAmount ?? throw new ArgumentNullException(nameof(_pointsAmount)),
            _description ?? throw new ArgumentNullException(nameof(_description)),
            _criteria);
    }
}
