using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeCommandHandlers;

public class TreeGoToCommandParser : ITreeCommandParser
{
    private ITreeCommandParser? _next;

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
        if (request.Current is not "goto")
            return _next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        string path = request.Current;

        return new TreeGoToCommand(path);
    }
}