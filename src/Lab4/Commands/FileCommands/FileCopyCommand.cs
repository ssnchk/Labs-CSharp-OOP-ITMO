using Itmo.ObjectOrientedProgramming.Lab4.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class FileCopyCommand : ICommand
{
    private readonly string _sourcePath;

    private readonly string _destinationPath;

    public FileCopyCommand(string sourcePath, string destinationPath)
    {
        _sourcePath = sourcePath;
        _destinationPath = destinationPath;
    }

    public ExecuteCommandResult Execute(FileSystemContext context)
    {
        if (context.FileExists(context.ParsePathToAbsolute(_sourcePath)) is false)
            return new ExecuteCommandResult.Failure();

        if (context.FileExists(context.ParsePathToAbsolute(_destinationPath)) is false)
            return new ExecuteCommandResult.Failure();

        if (context.CopyFile(_sourcePath, _destinationPath) is CopyFileResult.Failure)
            return new ExecuteCommandResult.Failure();

        return new ExecuteCommandResult.Success();
    }
}