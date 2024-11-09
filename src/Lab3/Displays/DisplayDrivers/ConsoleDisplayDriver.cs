using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;

public class ConsoleDisplayDriver : IDisplayDriver
{
    private Color? _color;

    public void Display(Message message)
    {
        if (_color is not null)
        {
            Console.WriteLine(SetColorForString(message.Title, _color.Value));
            Console.WriteLine(SetColorForString(message.Body, _color.Value));

            return;
        }

        Console.WriteLine(message.Title);
        Console.WriteLine(message.Body);
    }

    public void Clear()
    {
        Console.Clear();
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    private string SetColorForString(string str, Color color)
    {
        return Crayon.Output.Rgb(color.R, color.G, color.B).Text(str);
    }
}