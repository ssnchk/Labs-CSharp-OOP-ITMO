using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeCommandHandlers;

public class TreeTypeGoToCommandHandler : ITreeTypeCommandHandler
{
    private ITreeTypeCommandHandler? _next;

    public ITreeTypeCommandHandler AddNext(ITreeTypeCommandHandler handler)
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
        if (request.Current is not "goto")
            return _next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        string path = request.Current;

        return new TreeGoToCommand(path);
    }
}