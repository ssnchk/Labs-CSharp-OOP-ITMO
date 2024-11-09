using Itmo.ObjectOrientedProgramming.Lab3.Loggers;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.LoggingAddressees;

public class LoggingAddressee : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ILogger _logger;

    public LoggingAddressee(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee;
        _logger = logger;
    }

    public void ReceiveMessage(Message message)
    {
        _logger.Log("Addressee received message", message.Severity);
        _addressee.ReceiveMessage(message);
    }
}