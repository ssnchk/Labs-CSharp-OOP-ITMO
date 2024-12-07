using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.User;

public interface ICurrentUserTypeService
{
    UserType? User { get; }
}