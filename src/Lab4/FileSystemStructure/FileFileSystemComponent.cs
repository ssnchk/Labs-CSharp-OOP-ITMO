using Itmo.ObjectOrientedProgramming.Lab4.FileSystemVisitors;

namespace Itmo.ObjectOrientedProgramming.Lab4.FileSystemStructure;

public class FileFileSystemComponent : IFileSystemComponent
{
    public FileFileSystemComponent(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }
}