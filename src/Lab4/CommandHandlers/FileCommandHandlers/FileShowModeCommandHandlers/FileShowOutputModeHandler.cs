using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileShowModeCommandHandlers;

public class FileShowOutputModeHandler : IFileShowModeCommandHandler
{
    private IFileShowModeCommandHandler? _next;

    public IFileShowModeCommandHandler AddNext(IFileShowModeCommandHandler handler)
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

    public ICommand? Handle(IEnumerator<string> request, string path)
    {
        if (request.Current is not "-m")
            return _next?.Handle(request, path);

        if (request.MoveNext() is false)
            return null;

        ICommand? command = request.Current switch
        {
            "console" => new ConsoleFileShowCommand(path),
            _ => null,
        };

        return command;
    }
}