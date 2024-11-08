using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeUser : IAddressee
{
    private readonly IUser _user;

    public AddresseeUser(IUser user)
    {
        _user = user;
    }

    public void ReceiveMessage(Message message)
    {
        _user.ReceiveMessage(message);
    }
}