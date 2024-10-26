namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public record User
{
    public Guid Id { get; }

    public string Name { get; }

    public User(string name, Guid id)
    {
        Name = name;
        Id = id;
    }
}