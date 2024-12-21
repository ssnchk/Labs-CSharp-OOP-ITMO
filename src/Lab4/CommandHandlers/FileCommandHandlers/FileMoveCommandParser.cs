using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers;

public class FileMoveCommandParser : IFileCommandParser
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
        if (request.Current is not "move")
            return _next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        string sourcePath = request.Current;

        if (request.MoveNext() is false)
            return null;

        string destinationPath = request.Current;

        return new FileMoveCommand(sourcePath, destinationPath);
    }
}