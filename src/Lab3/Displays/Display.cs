using Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    private readonly IDisplayDriver _displayDriver;

    public Display(IDisplayDriver displayDriver)
    {
        _displayDriver = displayDriver;
    }

    public void DisplayMessage(Message message)
    {
        _displayDriver.Clear();
        _displayDriver.Display(message);
    }
}