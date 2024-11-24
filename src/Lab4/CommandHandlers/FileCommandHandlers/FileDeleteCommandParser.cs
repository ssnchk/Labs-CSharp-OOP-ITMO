using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers;

public class FileDeleteCommandParser : IFileCommandParser
{
    private IFileCommandParser? _next;

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
        if (request.Current is not "delete")
            return _next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        string path = request.Current;

        return new FileDeleteCommand(path);
    }
}