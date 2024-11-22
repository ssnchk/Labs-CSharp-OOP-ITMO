using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.ValueTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConsoleTreeListCommand : ICommand
{
    private readonly TreeDepth _depth;

    public ConsoleTreeListCommand(TreeDepth depth)
    {
        _depth = depth;
    }

    public void Execute(IFileSystemContext context)
    {
        context.ListDirectory(_depth);
    }
}