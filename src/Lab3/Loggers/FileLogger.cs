using Itmo.ObjectOrientedProgramming.Lab3.Severity;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class FileLogger : ILogger
{
    private readonly string _filePath;

    public FileLogger(string filePath)
    {
        if (!File.Exists(_filePath))
            throw new FileNotFoundException("File not found");

        _filePath = filePath;
    }

    public void Log(string message, SeverityLevel severity)
    {
        var writer = new StreamWriter(_filePath, true);
        writer.WriteLine($"{severity} | {DateTime.Now} | {message}");
    }
}