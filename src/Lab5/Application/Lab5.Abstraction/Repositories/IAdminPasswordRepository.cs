namespace Lab5.Abstraction.Repositories;

public interface IAdminPasswordRepository
{
    string? GetAdminPassword();

    bool TrySetPassword(string password);
}