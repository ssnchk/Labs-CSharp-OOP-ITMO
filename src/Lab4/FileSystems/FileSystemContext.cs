using Itmo.ObjectOrientedProgramming.Lab4.ValueTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class FileSystemContext : IFileSystemContext
{
    private IFileSystem? _fileSystem;

    public void Connect(IFileSystem fileSystem, string currentDirectory)
    {
        _fileSystem = fileSystem;
    }

    public void Disconnect()
    {
        _fileSystem = null;
    }

    public void ChangeDirectory(string path)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem, "File system is not connected");

        _fileSystem.ChangeDirectory(path);
    }

    public void ListDirectory(TreeDepth depth)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem, "File system is not connected");

        _fileSystem.ListDirectory(depth);
    }

    public string ReadFile(string path)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem, "File system is not connected");

        return _fileSystem.ReadFile(path);
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem, "File system is not connected");

        _fileSystem.MoveFile(sourcePath, destinationPath);
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem, "File system is not connected");

        _fileSystem.CopyFile(sourcePath, destinationPath);
    }

    public void DeleteFile(string path)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem, "File system is not connected");

        _fileSystem.DeleteFile(path);
    }

    public void RenameFile(string path, string newName)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem, "File system is not connected");

        _fileSystem.RenameFile(path, newName);
    }
}