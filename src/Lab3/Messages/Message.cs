using Itmo.ObjectOrientedProgramming.Lab3.Severity;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messages;

public record Message(string Title, string Body, SeverityLevel Severity);