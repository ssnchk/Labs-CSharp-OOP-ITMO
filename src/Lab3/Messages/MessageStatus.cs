using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public class MessageStatus
{
    public bool IsRead { get; private set; } = false;

    public MarkAsReadResult MarkAsRead()
    {
        if (IsRead)
            return new MarkAsReadResult.Failure("Message is already read");

        IsRead = true;

        return new MarkAsReadResult.Success();
    }
}