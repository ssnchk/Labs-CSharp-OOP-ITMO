using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    public void ReceiveMessage(Message message)
    {
        Console.WriteLine(message.Title);
        Console.WriteLine(message.Body);
        Console.WriteLine("messenger");
    }
}