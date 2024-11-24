using Itmo.ObjectOrientedProgramming.Lab4.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;

public class LocalConnectCommand : ICommand
{
    private readonly string _address;

    public LocalConnectCommand(ConnectCommandArguments arguments)
    {
        _address = arguments.Path;
    }

    public ExecuteCommandResult Execute(FileSystemContext context)
    {
        context.Connect(new LocalFileSystem(_address), _address);

        return new ExecuteCommandResult.Success();
    }
}