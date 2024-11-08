using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;

public class ConsoleDisplayDriver : IDisplayDriver
{
    private Color _color = Color.Black;

    public void Display(Message message)
    {
        Console.WriteLine(SetColorForString(message.Title));
        Console.WriteLine(SetColorForString(message.Body));
    }

    public void Clear()
    {
        Console.Clear();
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    private string SetColorForString(string str)
    {
        return Crayon.Output.Rgb(_color.R, _color.G, _color.B).Text(str);
    }
}