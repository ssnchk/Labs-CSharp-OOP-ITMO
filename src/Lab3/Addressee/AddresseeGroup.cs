using Itmo.ObjectOrientedProgramming.Lab3.Messages;

namespace Itmo.ObjectOrientedProgramming.Lab3.Addressee;

public class AddresseeGroup : IAddressee
{
    private readonly IReadOnlyCollection<IAddressee> _addressees;

    private AddresseeGroup(IReadOnlyCollection<IAddressee> addressees)
    {
        _addressees = addressees;
    }

    public void ReceiveMessage(Message message)
    {
        foreach (IAddressee addressee in _addressees)
        {
            addressee.ReceiveMessage(message);
        }
    }

    public class AddresseeGroupBuilder
    {
        private readonly List<IAddressee> _addressees = [];

        public void AddAddressee(IAddressee addressee)
            => _addressees.Add(addressee);

        public AddresseeGroup Build()
            => new AddresseeGroup(_addressees);
    }
}