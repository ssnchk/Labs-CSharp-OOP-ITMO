using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Models;

public interface IWithSupervisor
{
    public User Supervisor { get; }
}