namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IWithCriterias
{
    public IReadOnlyCollection<string> Criterias { get; }
}