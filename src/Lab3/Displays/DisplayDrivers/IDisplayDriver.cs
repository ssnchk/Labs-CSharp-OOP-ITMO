using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using System.Drawing;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays.DisplayDrivers;

public interface IDisplayDriver
{
    void Display(Message message);

    void Clear();

    void SetColor(Color color);
}