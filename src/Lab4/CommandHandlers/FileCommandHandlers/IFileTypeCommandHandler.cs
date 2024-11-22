using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers;

public interface IFileTypeCommandHandler
{
    IFileTypeCommandHandler AddNext(IFileTypeCommandHandler handler);

    ICommand? Handle(IEnumerator<string> request);
}