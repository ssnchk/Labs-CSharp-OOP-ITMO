using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ModeParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeCommandHandlers;

public class TreeListDirectoryCommandParser : ITreeCommandParser
{
    private readonly FlagParserBase<TreeListArguments.Builder>? _nextModeHandler;
    private ITreeCommandParser? _next;

    public TreeListDirectoryCommandParser(FlagParserBase<TreeListArguments.Builder>? nextModeHandler)
    {
        _nextModeHandler = nextModeHandler;
    }

    public ITreeCommandParser AddNext(ITreeCommandParser parser)
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
        if (request.Current is not "list")
            return _next?.Handle(request);

        if (request.MoveNext() is false || _nextModeHandler is null)
            return null;

        TreeListArguments.Builder? builder = _nextModeHandler.Handle(request, new TreeListArguments.Builder());

        if (builder is null)
            return null;

        TreeListArguments arguments = builder.Build();

        if (arguments.Depth is null)
            return null;

        return new ConsoleTreeListCommand(arguments);
    }
}