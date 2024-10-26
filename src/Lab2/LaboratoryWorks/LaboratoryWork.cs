using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;
using Itmo.ObjectOrientedProgramming.Lab2.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks;

public class LaboratoryWork : ILaboratoryWork<LaboratoryWork>
{
    public LaboratoryWork(
        User author,
        string name,
        Guid id,
        Guid? initialId,
        Points pointsAmount,
        string description,
        IReadOnlyCollection<string> criterias)
    {
        Author = author;
        Name = name;
        Id = id;
        PointsAmount = pointsAmount;
        Description = description;
        Criterias = criterias;
        InitialId = initialId;
    }

    public Guid Id { get; }

    public Guid? InitialId { get; }

    public IReadOnlyCollection<string> Criterias { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public Points PointsAmount { get; }

    public User Author { get; }

    public SetCriteriasResult SetCriterias(IReadOnlyCollection<string> criterias, User user)
    {
        if (!user.Equals(Author))
            return new SetCriteriasResult.Failure("User is not author");

        Criterias = criterias;

        return new SetCriteriasResult.Success();
    }

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

    public LaboratoryWork Clone(Guid newId, User newAuthor)
    {
        if (newId.Equals(Id))
            throw new ArgumentException("newId cannot be equal to Id");

        return new LaboratoryWork(
            newAuthor,
            Name,
            newId,
            Id,
            PointsAmount,
            Description,
            Criterias);
    }
}