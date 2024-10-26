using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks;

public interface ILaboratoryWork
{
    public Guid Id { get; }

    public Guid? ParentId { get; }

    public IReadOnlyCollection<string> Criterias { get; }

    public string Name { get; }

    public string Description { get; }

    public Points PointsAmount { get; }

    public User Author { get; }

    SetCriteriasResult SetCriterias(IReadOnlyCollection<string> criterias, User user);

    SetNameResult SetName(string name, User user);

    SetDescriptionResult SetDescription(string description, User user);
}

public interface ILaboratoryWork<out T> : ILaboratoryWork
    where T : ILaboratoryWork<T>
{
    T Clone(Guid newId, User newAuthor);
}