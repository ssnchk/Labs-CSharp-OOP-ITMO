using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User : IUser
{
    private readonly Dictionary<Message, MessageStatus> _messages = [];

    public IReadOnlyDictionary<Message, MessageStatus> Messages => _messages;

    public void ReceiveMessage(Message message)
    {
        _messages[message] = new MessageStatus();
    }
}