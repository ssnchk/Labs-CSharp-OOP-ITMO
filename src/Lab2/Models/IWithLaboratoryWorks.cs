using Itmo.ObjectOrientedProgramming.Lab2.LaboratoryWorks;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IWithLaboratoryWorks
{
    public IReadOnlyCollection<ILaboratoryWork> LaboratoryWorks { get; }
}