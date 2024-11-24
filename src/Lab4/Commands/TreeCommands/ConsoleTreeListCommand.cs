using Itmo.ObjectOrientedProgramming.Lab4.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.ValueTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands;

public class ConsoleTreeListCommand : ICommand
{
    private readonly TreeDepth _depth;

    public ConsoleTreeListCommand(TreeListArguments arguments)
    {
        ArgumentNullException.ThrowIfNull(arguments.Depth);
        _depth = arguments.Depth;
    }

    public ExecuteCommandResult Execute(FileSystemContext context)
    {
        if (context.ListDirectory(_depth) is ListDirectoryResult.Failure)
            return new ExecuteCommandResult.Failure();

        return new ExecuteCommandResult.Success();
    }
}