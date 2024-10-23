using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IWithAuthor
{
    public User Author { get; }
}