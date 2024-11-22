using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.ValueTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeCommandHandlers.TreeListModeCommandHandlers;

public class TreeListDepthModeCommandHandler : ITreeListModeCommandHandler
{
    private ITreeListModeCommandHandler? _next;

    public ITreeListModeCommandHandler AddNext(ITreeListModeCommandHandler handler)
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
        if (request.Current is not "-d")
            return _next?.Handle(request);

        if (request.MoveNext() is false)
            return null;

        int depth = int.Parse(request.Current);

        return new ConsoleTreeListCommand(new TreeDepth(depth));
    }
}