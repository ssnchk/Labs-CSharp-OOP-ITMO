namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

public interface IFileSystemContext : IFileSystem
{
    void Connect(IFileSystem fileSystem, string currentDirectory);

    void Disconnect();
}