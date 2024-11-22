using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectModeCommandHandlers;

public class ConnectModeTypeHandler : IConnectModeCommandHandler
{
    private IConnectModeCommandHandler? _next;

    public IConnectModeCommandHandler AddNext(IConnectModeCommandHandler handler)
    {
        if (_next is null)
        {
            _next = handler;
        }
        else
        {
            _next.AddNext(handler);
        }

        return this;
    }

    public ICommand? Handle(IEnumerator<string> request, string address)
    {
        if (request.Current is not "-m")
            return _next?.Handle(request, address);

        if (request.MoveNext() is false)
            return null;

        ICommand? command = request.Current switch
        {
            "local" => new LocalConnectCommand(address),
            _ => null,
        };

        return command;
    }
}