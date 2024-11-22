using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConsoleFileShowCommand : ICommand
{
    private readonly string path;

    public ConsoleFileShowCommand(string path)
    {
        this.path = path;
    }

    public void Execute(IFileSystemContext context)
    {
        Console.WriteLine(context.ReadFile(path));
    }
}