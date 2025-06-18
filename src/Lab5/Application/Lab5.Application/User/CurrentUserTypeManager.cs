using Lab5.Contracts.User;
using Lab5.Models.Users;

namespace Lab5.Application.User;

public class CurrentUserTypeManager : ICurrentUserTypeService
{
    public UserType? User { get; set; }
}