namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class ConsoleLogger : ILogger
{
    public void Log(string message, int severity)
    {
        Console.WriteLine($"{severity} | {DateTime.Now} | {message}");
    }
}
