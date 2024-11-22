using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class LocalConnectCommand : ICommand
{
    private readonly string _address;

    public LocalConnectCommand(string address)
    {
        _address = address;
    }

    public void Execute(IFileSystemContext context)
    {
        context.Connect(new LocalFileSystem(_address), _address);
    }
}