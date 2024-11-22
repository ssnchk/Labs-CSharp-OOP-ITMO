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
        if (!Directory.Exists(address))
            throw new DirectoryNotFoundException($"Директория не найдена: {address}");

        _address = address;
        _currentDirectory = address;
    }

    public void ChangeDirectory(string path)
    {
        string absolutePath = ParsePathToAbsolute(_address, path);

        if (!Directory.Exists(absolutePath))
            throw new DirectoryNotFoundException($"Директория не найдена: {path}");

        _currentDirectory = absolutePath;
    }

    public void ListDirectory(TreeDepth depth)
    {
        var factory = new FileSystemComponentFactory();
        IFileSystemComponent component = factory.Create(_currentDirectory);

        var visitor = new ConsoleVisitor();

        component.Accept(visitor);
    }

    public string ReadFile(string path)
    {
        string absolutePath = ParsePathToAbsolute(_currentDirectory, path);

        if (!File.Exists(absolutePath))
            throw new FileNotFoundException($"Файл не найден: {path}");

        return File.ReadAllText(absolutePath);
    }

    public void MoveFile(string sourcePath, string destinationPath)
    {
        string absoluteSourcePath = ParsePathToAbsolute(_currentDirectory, sourcePath);
        string absoluteDestinationPath = ParsePathToAbsolute(_currentDirectory, destinationPath);

        if (!File.Exists(absoluteSourcePath))
            throw new FileNotFoundException($"Файл не найден: {sourcePath}");

        if (!Directory.Exists(absoluteDestinationPath))
            throw new DirectoryNotFoundException($"Директория не найдена: {destinationPath}");

        File.Move(absoluteSourcePath, absoluteDestinationPath);
    }

    public void CopyFile(string sourcePath, string destinationPath)
    {
        string absoluteSourcePath = ParsePathToAbsolute(_currentDirectory, sourcePath);
        string absolutDestinationPath = ParsePathToAbsolute(_currentDirectory, destinationPath);

        if (!File.Exists(absoluteSourcePath))
            throw new FileNotFoundException($"Файл не найден: {sourcePath}");

        if (!Directory.Exists(absolutDestinationPath))
            throw new DirectoryNotFoundException($"Директория не найдена: {destinationPath}");

        File.Copy(absoluteSourcePath, absolutDestinationPath);
    }

    public void DeleteFile(string path)
    {
        string absolutePath = ParsePathToAbsolute(_currentDirectory, path);

        if (!File.Exists(absolutePath))
            throw new FileNotFoundException($"Файл не найден: {path}");

        File.Delete(absolutePath);
    }

    public void RenameFile(string path, string newName)
    {
        string absolutePath = ParsePathToAbsolute(_currentDirectory, path);
        string? directoryName = Path.GetDirectoryName(absolutePath);
        string newFilePath = Path.Combine(directoryName ?? string.Empty, newName);

        if (!File.Exists(absolutePath))
            throw new FileNotFoundException($"Файл не найден: {path}");

        File.Move(absolutePath, newFilePath);
    }

    private string ParsePathToAbsolute(string basePath, string relativeOrAbsolutePath)
        => Path.IsPathRooted(relativeOrAbsolutePath)
            ? relativeOrAbsolutePath
            : Path.Combine(basePath, relativeOrAbsolutePath);
}