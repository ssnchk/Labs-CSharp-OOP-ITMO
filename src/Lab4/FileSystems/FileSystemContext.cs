using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.ValueTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class FileSystemContext
{
    private IFileSystem _fileSystem = new NullFileSystem();

    public void Connect(IFileSystem fileSystem, string currentDirectory)
    {
        _fileSystem = fileSystem;
    }

    public void Disconnect()
    {
        _fileSystem = new NullFileSystem();
    }

    public ChangeDirectoryResult ChangeDirectory(string path)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem, "File system is not connected");

        return _fileSystem.ChangeDirectory(path);
    }

    public ListDirectoryResult ListDirectory(TreeDepth depth)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem, "File system is not connected");

        return _fileSystem.ListDirectory(depth);
    }

    public ReadFileResult ReadFile(string path)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem, "File system is not connected");

        return _fileSystem.ReadFile(path);
    }

    public MoveFileResult MoveFile(string sourcePath, string destinationPath)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem, "File system is not connected");

        return _fileSystem.MoveFile(sourcePath, destinationPath);
    }

    public CopyFileResult CopyFile(string sourcePath, string destinationPath)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem, "File system is not connected");

        return _fileSystem.CopyFile(sourcePath, destinationPath);
    }

    public DeleteFileResult DeleteFile(string path)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem, "File system is not connected");

        return _fileSystem.DeleteFile(path);
    }

    public RenameFileResult RenameFile(string path, string newName)
    {
        ArgumentNullException.ThrowIfNull(_fileSystem, "File system is not connected");

        return _fileSystem.RenameFile(path, newName);
    }

    public string ParsePathToAbsolute(string path)
    {
        return _fileSystem.ParsePathToAbsolute(path);
    }

    public bool DirectoryExists(string path)
    {
        return _fileSystem.DirectoryExists(path);
    }

    public bool FileExists(string path)
    {
        return _fileSystem.FileExists(path);
    }
}