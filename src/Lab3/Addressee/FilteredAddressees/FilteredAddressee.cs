using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee.FilteredAddressees;

public class FilteredAddressee : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly Func<int, bool> _filter;

    public FilteredAddressee(IAddressee addressee, Func<int, bool> filter)
    {
        _addressee = addressee;
        _filter = filter;
    }

    public void ReceiveMessage(Message message)
    {
        if (!_filter(message.Severity))
            return;

        _addressee.ReceiveMessage(message);
    }
}