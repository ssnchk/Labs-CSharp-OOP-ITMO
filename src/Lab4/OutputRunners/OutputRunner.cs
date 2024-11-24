using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.FileSystems;

namespace Itmo.ObjectOrientedProgramming.Lab4.OutputRunners;

public class OutputRunner : IOutputRunner
{
    private readonly ArgumentSeparator _separator;
    private readonly ICommandHandler _commandHandler;
    private readonly FileSystemContext _fileSystemContext = new FileSystemContext();

    public OutputRunner(ICommandHandler commandHandler, ArgumentSeparator separator)
    {
        _commandHandler = commandHandler;
        _separator = separator;
    }

    public void Run()
    {
        string? input;

        while (true)
        {
            input = Console.ReadLine();

            ICommand? command = _commandHandler.Handle(
                _separator.Separate(input));

            if (command is null)
            {
                Console.WriteLine("Unknown command");
                continue;
            }

            command.Execute(_fileSystemContext);
        }
    }
}