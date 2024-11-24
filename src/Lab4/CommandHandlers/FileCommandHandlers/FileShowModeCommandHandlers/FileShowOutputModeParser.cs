using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ModeParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileShowModeCommandHandlers;

public class FileShowOutputModeParser : FlagParserBase<FileShowArguments.Builder>
{
    public override FileShowArguments.Builder? Handle(
        IEnumerator<string> request,
        FileShowArguments.Builder argumentBuilder)
    {
        if (request.Current is not "-m")
            return Next?.Handle(request, argumentBuilder);

        if (request.MoveNext() is false)
            return null;

        switch (request.Current)
        {
            case "console":
                argumentBuilder.WithMode(FileShowModes.Console);
                break;
            default:
                return null;
        }

        return argumentBuilder;
    }
}