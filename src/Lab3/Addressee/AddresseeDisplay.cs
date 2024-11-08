using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeDisplay : IAddressee
{
    private readonly IDisplay _display;

    public AddresseeDisplay(IDisplay display)
    {
        _display = display;
    }

    public void ReceiveMessage(Message message)
    {
        _display.DisplayMessage(message);
    }
}