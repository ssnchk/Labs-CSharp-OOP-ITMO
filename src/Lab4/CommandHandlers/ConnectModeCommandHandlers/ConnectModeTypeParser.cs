using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ModeParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectModeCommandHandlers;

public class ConnectModeTypeParser : FlagParserBase<ConnectCommandArguments.Builder>
{
    public override ConnectCommandArguments.Builder? Handle(IEnumerator<string> request, ConnectCommandArguments.Builder argumentBuilder)
    {
        if (request.Current is not "-m")
            return Next?.Handle(request, argumentBuilder);

        if (request.MoveNext() is false)
            return null;

        switch (request.Current)
        {
            case "local":
                argumentBuilder.WithMode(FileSystemModes.Local);
                break;
            default:
                return null;
        }

        return argumentBuilder;
    }
}