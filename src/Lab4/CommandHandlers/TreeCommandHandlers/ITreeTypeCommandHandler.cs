using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeCommandHandlers;

public interface ITreeTypeCommandHandler
{
    ITreeTypeCommandHandler AddNext(ITreeTypeCommandHandler handler);

    ICommand? Handle(IEnumerator<string> request);
}