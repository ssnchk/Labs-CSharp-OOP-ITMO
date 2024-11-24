using Itmo.ObjectOrientedProgramming.Lab4.FileSystems.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystemVisitors;
using Itmo.ObjectOrientedProgramming.Lab4.ValueTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public class LocalFileSystem : IFileSystem
{
    private readonly string _address;

    private string _currentDirectory;

    public LocalFileSystem(string address)
    {
        _address = address;
        _currentDirectory = address;
    }

    public ChangeDirectoryResult ChangeDirectory(string path)
    {
        _currentDirectory = path;

        return new ChangeDirectoryResult.Success();
    }

    public ListDirectoryResult ListDirectory(TreeDepth depth)
    {
        var factory = new FileSystemComponentFactory();
        IFileSystemComponent component = factory.Create(_currentDirectory);

        var visitor = new ConsoleVisitor();

        component.Accept(visitor);

        return new ListDirectoryResult.Success();
    }

    public ReadFileResult ReadFile(string path)
    {
        return new ReadFileResult.Success(File.ReadAllText(path));
    }

    public MoveFileResult MoveFile(string sourcePath, string destinationPath)
    {
        File.Move(sourcePath, destinationPath);

        return new MoveFileResult.Success();
    }

    public CopyFileResult CopyFile(string sourcePath, string destinationPath)
    {
        File.Copy(sourcePath, destinationPath);

        return new CopyFileResult.Success();
    }

    public DeleteFileResult DeleteFile(string path)
    {
        File.Delete(path);

        return new DeleteFileResult.Success();
    }

    public RenameFileResult RenameFile(string path, string newName)
    {
        string? directoryName = Path.GetDirectoryName(path);
        string newFilePath = Path.Combine(directoryName ?? string.Empty, newName);

        File.Move(path, newFilePath);

        return new RenameFileResult.Success();
    }

    public string ParsePathToAbsolute(string path)
        => Path.IsPathRooted(path)
            ? path
            : Path.Combine(_address, path);

    public bool DirectoryExists(string path)
    {
        return Directory.Exists(path) && IsRootedToFileSystem(path);
    }

    public bool FileExists(string path)
    {
        return File.Exists(path) && IsRootedToFileSystem(path);
    }

    private bool IsRootedToFileSystem(string path)
    {
        return path.StartsWith(_address) && path.Length > _address.Length &&
               path[_address.Length] == Path.DirectorySeparatorChar;
    }
}