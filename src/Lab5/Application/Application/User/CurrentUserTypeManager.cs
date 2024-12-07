using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.User;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Models.Users;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Application.User;

public class CurrentUserTypeManager : ICurrentUserTypeService
{
    public UserType? User { get; set; }
}