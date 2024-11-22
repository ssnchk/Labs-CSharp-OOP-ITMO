using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectModeCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class ConnectCommandHandler : CommandHandlerBase
{
    private readonly IConnectModeCommandHandler? _modeHandler;

    public ConnectCommandHandler(IConnectModeCommandHandler? modeHandler)
    {
        _modeHandler = modeHandler;
    }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "connect")
            return Next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        string fileSystemAddress = request.Current;

        if (request.MoveNext() is false || _modeHandler is null)
            return null;

        return _modeHandler.Handle(request, fileSystemAddress);
    }
}