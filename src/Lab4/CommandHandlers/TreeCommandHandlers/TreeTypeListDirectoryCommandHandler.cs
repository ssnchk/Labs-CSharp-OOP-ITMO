using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeCommandHandlers.TreeListModeCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeCommandHandlers;

public class TreeTypeListDirectoryCommandHandler : ITreeTypeCommandHandler
{
    private readonly ITreeListModeCommandHandler? _nextModeHandler;
    private ITreeTypeCommandHandler? _next;

    public TreeTypeListDirectoryCommandHandler(ITreeListModeCommandHandler? nextModeHandler)
    {
        _nextModeHandler = nextModeHandler;
    }

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
        if (request.Current is not "list")
            return _next?.Handle(request);

        if (request.MoveNext() is false || _nextModeHandler is null)
            return null;

        return _nextModeHandler.Handle(request);
    }
}