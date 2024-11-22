using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class FileRenameCommand : ICommand
{
    private readonly string _filePath;

    private readonly string _newName;

    public FileRenameCommand(string filePath, string newName)
    {
        _filePath = filePath;
        _newName = newName;
    }

    public void Execute(IFileSystemContext context)
    {
        context.RenameFile(_filePath, _newName);
    }
}