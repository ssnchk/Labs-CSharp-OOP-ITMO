using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileShowModeCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers;

public class FileShowCommandHandler : IFileTypeCommandHandler
{
    private readonly IFileShowModeCommandHandler _nextModeHandler;
    private IFileTypeCommandHandler? _next;

    public FileShowCommandHandler(IFileShowModeCommandHandler nextModeHandler)
    {
        _nextModeHandler = nextModeHandler;
    }

    public IFileTypeCommandHandler AddNext(IFileTypeCommandHandler handler)
    {
        if (_next is null)
        {
            _next = handler;
        }
        else
        {
            _next.AddNext(handler);
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

        return _nextModeHandler.Handle(request, path);
    }
}