using Itmo.ObjectOrientedProgramming.Lab3.Severity;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public interface ILogger
{
    public void Log(string message, SeverityLevel severity);
}