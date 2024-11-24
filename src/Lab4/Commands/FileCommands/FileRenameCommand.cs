using Itmo.ObjectOrientedProgramming.Lab4.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class FileRenameCommand : ICommand
{
    private readonly string _filePath;

    private readonly string _newName;

    public FileRenameCommand(string filePath, string newName)
    {
        _filePath = filePath;
        _newName = newName;
    }

    public ExecuteCommandResult Execute(FileSystemContext context)
    {
        if (context.FileExists(context.ParsePathToAbsolute(_filePath)) is false)
            return new ExecuteCommandResult.Failure();

        if (context.RenameFile(_filePath, _newName) is RenameFileResult.Failure)
            return new ExecuteCommandResult.Failure();

        return new ExecuteCommandResult.Success();
    }
}