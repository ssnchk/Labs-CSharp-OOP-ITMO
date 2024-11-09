using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;

public class FileDisplayDriver : IDisplayDriver
{
    private readonly string _filePath;

    private Color? _color;

    public FileDisplayDriver(string filePath)
    {
        _filePath = filePath;
    }

    public void Display(Message message)
    {
        if (_color is not null)
        {
            WriteColoredStringToFile(_color.Value, message.Title);
            WriteColoredStringToFile(_color.Value, message.Body);

            return;
        }

        WriteStringToFile(message.Title);
        WriteStringToFile(message.Body);
    }

    public void Clear()
    {
        File.WriteAllText(_filePath, string.Empty);
    }

    public void SetColor(Color color)
    {
        _color = color;
    }

    private void WriteColoredStringToFile(Color color, string text)
    {
        string ansiColorCode = $"\u001b[38;2;{color.R};{color.G};{color.B}m";
        string coloredText = $"{ansiColorCode}{text}";

        WriteStringToFile(coloredText);
    }

    private void WriteStringToFile(string text)
    {
        File.AppendAllText(_filePath, text);
    }
}