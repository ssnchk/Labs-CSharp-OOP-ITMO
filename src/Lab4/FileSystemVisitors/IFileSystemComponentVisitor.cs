using Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemVisitors;

public interface IFileSystemComponentVisitor
{
    void Visit(FileFileSystemComponent component);

    void Visit(DirectoryFileSystemComponent component);
}