using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileDeleteCommand : ICommand
{
    private readonly string _filePath;

    public FileDeleteCommand(string filePath)
    {
        _filePath = filePath;
    }

    public void Execute(IFileSystemContext context)
    {
        context.DeleteFile(_filePath);
    }
}