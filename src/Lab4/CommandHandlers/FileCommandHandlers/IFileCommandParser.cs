using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers;

public interface IFileCommandParser
{
    IFileCommandParser AddNext(IFileCommandParser parser);

    ICommand? Handle(IEnumerator<string> request);
}