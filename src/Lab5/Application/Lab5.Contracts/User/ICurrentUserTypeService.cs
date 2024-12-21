using Lab5.Models.Users;

namespace Lab5.Contracts.User;

public interface ICurrentUserTypeService
{
    UserType? User { get; }
}