using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public interface IRecipient
{
    void ReceiveMessage(Message message);
}