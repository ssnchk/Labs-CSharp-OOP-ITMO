using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks;

public interface ILaboratoryWork : IWithAuthor, IWithId, IWithInitialId, IWithDescription, IWithPointsAmount, IWithCriterias, IWithName
{
    public SetCriteriasResult SetCriterias(IReadOnlyCollection<string> criterias, User user);

    public SetNameResult SetName(string name, User user);

    public SetDescriptionResult SetDescription(string description, User user);
}

public interface ILaboratoryWork<out T> : ILaboratoryWork
    where T : ILaboratoryWork<T>
{
    public T Clone(Guid newId, User newAuthor);
}
