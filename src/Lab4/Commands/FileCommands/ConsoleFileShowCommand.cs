using Itmo.ObjectOrientedProgramming.Lab4.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

public class ConsoleFileShowCommand : ICommand
{
    private readonly string _path;

    public ConsoleFileShowCommand(FileShowArguments arguments)
    {
        _path = arguments.Path;
    }

    public ExecuteCommandResult Execute(FileSystemContext context)
    {
        if (context.FileExists(context.ParsePathToAbsolute(_path)) is false)
            return new ExecuteCommandResult.Failure();

        ReadFileResult readResult = context.ReadFile(_path);

        if (readResult is not ReadFileResult.Success content)
            return new ExecuteCommandResult.Failure();

        Console.WriteLine(content.Content);

        return new ExecuteCommandResult.Success();
    }
}