using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks.Builders;

public interface ILaboratoryWorkBuilder
{
    public ILaboratoryWorkBuilder WithName(string name);

    public ILaboratoryWorkBuilder WithDescription(string description);

    public ILaboratoryWorkBuilder WithId(Guid id);

    public ILaboratoryWorkBuilder WithPointsAmount(Points pointsAmount);

    public ILaboratoryWorkBuilder AddCriteria(string criteria);

    public ILaboratoryWorkBuilder WithAuthor(User author);

    ILaboratoryWork Build();
}