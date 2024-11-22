using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class FileCommandHandler : CommandHandlerBase
{
    private readonly IFileTypeCommandHandler? _nextFileHandler;

    public FileCommandHandler(IFileTypeCommandHandler? nextFileHandler)
    {
        _nextFileHandler = nextFileHandler;
    }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "file")
            return Next?.Handle(request);

        if (request.MoveNext() is false || _nextFileHandler is null)
            return null;

        return _nextFileHandler.Handle(request);
    }
}