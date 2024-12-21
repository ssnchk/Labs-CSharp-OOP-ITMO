using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ModeParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers;

public class FileShowCommandParser : IFileCommandParser
{
    private readonly FlagParserBase<FileShowArguments.Builder> _nextModeParser;
    private IFileCommandParser? _next;

    public FileShowCommandParser(FlagParserBase<FileShowArguments.Builder> nextModeParser)
    {
        _nextModeParser = nextModeParser;
    }

    public IFileCommandParser AddNext(IFileCommandParser parser)
    {
        if (_next is null)
        {
            _next = parser;
        }
        else
        {
            _next.AddNext(parser);
        }

        return this;
    }

    public ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "show")
            return _next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        string path = request.Current;

        if (request.MoveNext() is false)
            return null;

        FileShowArguments.Builder? builder =
            _nextModeParser.Handle(request, new FileShowArguments.Builder().WithPath(path));

        if (builder is null)
            return null;

        FileShowArguments arguments = builder.Build();

        if (arguments.Mode is null)
            return null;

        return arguments.Mode switch
        {
            FileShowModes.Console => new ConsoleFileShowCommand(arguments),
            _ => _next?.Handle(request),
        };
    }
}