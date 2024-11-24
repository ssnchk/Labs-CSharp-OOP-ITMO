using Itmo.ObjectOrientedProgramming.Lab4.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class FileDeleteCommand : ICommand
{
    private readonly string _filePath;

    public FileDeleteCommand(string filePath)
    {
        _filePath = filePath;
    }

    public ExecuteCommandResult Execute(FileSystemContext context)
    {
        if (context.FileExists(context.ParsePathToAbsolute(_filePath)) is false)
            return new ExecuteCommandResult.Failure();

        if (context.DeleteFile(_filePath) is DeleteFileResult.Failure)
            return new ExecuteCommandResult.Failure();

        return new ExecuteCommandResult.Success();
    }
}