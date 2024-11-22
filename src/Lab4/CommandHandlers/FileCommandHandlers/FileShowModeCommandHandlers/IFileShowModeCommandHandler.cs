using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileShowModeCommandHandlers;

public interface IFileShowModeCommandHandler
{
    IFileShowModeCommandHandler AddNext(IFileShowModeCommandHandler handler);

    ICommand? Handle(IEnumerator<string> request, string path);
}