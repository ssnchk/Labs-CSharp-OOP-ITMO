namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User
{
    public Guid Id { get; }

    public string Name { get; }

    public User(string name, Guid id)
    {
        Name = name;
        Id = id;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;

        if (obj is not User user) return false;

        return user.Id == Id && user.Name == Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name);
    }
}