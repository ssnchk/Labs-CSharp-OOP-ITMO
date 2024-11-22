using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class TreeCommandHandler : CommandHandlerBase
{
    private readonly ITreeTypeCommandHandler? _nextTreeHandler;

    public TreeCommandHandler(ITreeTypeCommandHandler? nextTreeHandler)
    {
        _nextTreeHandler = nextTreeHandler;
    }

    public override ICommand? Handle(IEnumerator<string> request)
    {
        if (request.Current is not "tree")
            return Next?.Handle(request);

        if (request.MoveNext() is false || _nextTreeHandler is null)
            return null;

        return _nextTreeHandler.Handle(request);
    }
}