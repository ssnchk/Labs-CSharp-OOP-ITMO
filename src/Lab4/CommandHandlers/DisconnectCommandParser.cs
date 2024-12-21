using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class DisconnectCommandParser : CommandParserBase
{
    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "disconnect")
            return Next?.Handle(request);

        return new DisconnectCommand();
    }
}