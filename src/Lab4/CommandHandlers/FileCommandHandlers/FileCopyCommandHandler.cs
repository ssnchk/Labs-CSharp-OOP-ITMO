using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers;

public class FileCopyCommandHandler : IFileTypeCommandHandler
{
    private IFileTypeCommandHandler? _next;

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
        if (request.Current is not "copy")
            return _next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        string sourcePath = request.Current;

        if (request.MoveNext() is false)
            return null;

        string destinationPath = request.Current;

        return new FileCopyCommand(sourcePath, destinationPath);
    }
}