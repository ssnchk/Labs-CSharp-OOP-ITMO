using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Severity;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.FilteredAddressees;

public class FilteredAddressee : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly SeverityLevel _filter;

    public FilteredAddressee(IAddressee addressee, SeverityLevel filter)
    {
        _addressee = addressee;
        _filter = filter;
    }

    public void ReceiveMessage(Message message)
    {
        if (message.Severity != _filter)
            return;

        _addressee.ReceiveMessage(message);
    }
}