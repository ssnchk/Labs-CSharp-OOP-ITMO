using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeCommandHandlers.TreeListModeCommandHandlers;

public interface ITreeListModeCommandHandler
{
    ITreeListModeCommandHandler AddNext(ITreeListModeCommandHandler handler);

    ICommand? Handle(IEnumerator<string> request);
}