using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeCommandHandlers;

public interface ITreeCommandParser
{
    ITreeCommandParser AddNext(ITreeCommandParser parser);

    ICommand? Handle(IEnumerator<string> request);
}