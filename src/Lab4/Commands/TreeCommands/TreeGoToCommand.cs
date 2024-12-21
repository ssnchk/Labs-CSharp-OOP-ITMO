using Itmo.ObjectOrientedProgramming.Lab4.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands;

public class TreeGoToCommand : ICommand
{
    private readonly string _path;

    public TreeGoToCommand(string path)
    {
        _path = path;
    }

    public ExecuteCommandResult Execute(FileSystemContext context)
    {
        if (!context.DirectoryExists(_path))
            return new ExecuteCommandResult.Failure();

        if (context.ChangeDirectory(_path) is ChangeDirectoryResult.Failure)
            return new ExecuteCommandResult.Failure();

        return new ExecuteCommandResult.Success();
    }
}