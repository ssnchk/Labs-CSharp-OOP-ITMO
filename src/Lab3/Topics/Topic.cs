using Itmo.ObjectOrientedProgramming.Lab3.Addressee;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic
{
    public string Name { get; }

    private readonly List<IAddressee> _addressees = [];

    public Topic(string name)
    {
        Name = name;
    }

    public void AddAddressee(IAddressee addressee)
    {
        _addressees.Add(addressee);
    }

    public void SendMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.ReceiveMessage(message);
        }
    }
}