using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.OutputRunners;

public class OutputRunner : IOutputRunner
{
    private readonly ICommandHandler _commandHandler;
    private readonly IFileSystemContext _fileSystemContext = new FileSystemContext();

    public OutputRunner(ICommandHandler commandHandler)
    {
        _commandHandler = commandHandler;
    }

    public void Run(IEnumerable<string> args)
    {
        using IEnumerator<string> request = args.GetEnumerator();

        while (request.MoveNext())
        {
            ICommand? command = _commandHandler.Handle(request);

            if (command is null)
            {
                Console.WriteLine("Unknown command");
                continue;
            }

            command.Execute(_fileSystemContext);
        }
    }
}