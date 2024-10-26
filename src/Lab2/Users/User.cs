using Itmo.ObjectOrientedProgramming.Lab2.IdGenerators;

namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public record User(string Name)
{
    public long Id { get; } = IdGenerator.GenerateNewId();
}