using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User : IUser
{
    private readonly List<MessageWithReadStatus> _messages = [];

    public IReadOnlyList<MessageWithReadStatus> Messages => _messages;

    public void ReceiveMessage(Message message)
    {
        _messages.Add(new MessageWithReadStatus(message));
    }
}