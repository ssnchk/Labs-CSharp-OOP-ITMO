using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ModeParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class ConnectCommandParser : CommandParserBase
{
    private readonly FlagParserBase<ConnectCommandArguments.Builder> _modeHandler;

    public ConnectCommandParser(FlagParserBase<ConnectCommandArguments.Builder> modeHandler)
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

        if (request.MoveNext() is false)
            return null;

        ConnectCommandArguments.Builder? builder =
            _modeHandler.Handle(request, new ConnectCommandArguments.Builder().WithPath(fileSystemAddress));

        if (builder is null)
            return null;

        ConnectCommandArguments arguments = builder.Build();

        if (arguments.Mode is null)
            return null;

        return arguments.Mode switch
        {
            FileSystemModes.Local => new LocalConnectCommand(arguments),
            _ => null,
        };
    }
}