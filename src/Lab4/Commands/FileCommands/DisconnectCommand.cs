using Itmo.ObjectOrientedProgramming.Lab4.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class DisconnectCommand : ICommand
{
    public ExecuteCommandResult Execute(FileSystemContext context)
    {
        context.Disconnect();

        return new ExecuteCommandResult.Success();
    }
}