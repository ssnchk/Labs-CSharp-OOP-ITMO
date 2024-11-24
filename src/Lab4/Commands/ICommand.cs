using Itmo.ObjectOrientedProgramming.Lab4.Commands.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public interface ICommand
{
    ExecuteCommandResult Execute(FileSystemContext context);
}