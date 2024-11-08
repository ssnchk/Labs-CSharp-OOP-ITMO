using Itmo.ObjectOrientedProgramming.Lab3.Severity;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class ConsoleLogger : ILogger
{
    public void Log(string message, SeverityLevel severity)
    {
        Console.WriteLine($"{severity} | {DateTime.Now} | {message}");
    }
}
