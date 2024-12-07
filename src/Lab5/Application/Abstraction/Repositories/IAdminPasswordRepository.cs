namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstraction.Repositories;

public interface IAdminPasswordRepository
{
    string? GetAdminPassword();

    bool TrySetPassword(string password);
}