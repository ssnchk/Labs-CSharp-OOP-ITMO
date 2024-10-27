using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks;

public interface ILaboratoryWork : IIdentifiable, ILaboratoryWorkBuilderDirector
{
    public long? ParentId { get; }

    public IReadOnlyCollection<string> Criterias { get; }

    public string Name { get; }

    public string Description { get; }

    public Points PointsAmount { get; }

    public User Author { get; }

    public User CurrentUser { get; }

    void SetCurrentUser(User user);

    UpdateLaboratoryWorkResult Update(string name, string description, Points pointsAmount, IReadOnlyCollection<string> criterias);
}

public interface ILaboratoryWork<out T> : ILaboratoryWork
    where T : ILaboratoryWork<T>
{
    T Clone();
}