using Itmo.ObjectOrientedProgramming.Lab4.FileSystemVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public interface IFileSystemComponent
{
    string Name { get; }

    void Accept(IFileSystemComponentVisitor visitor);
}