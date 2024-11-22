using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectModeCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileShowModeCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeCommandHandlers.TreeListModeCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.OutputRunners;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static void Main(string[] args)
    {
        var runner = new OutputRunner(CreateParserChain());
        runner.Run(args);
    }

    public static ICommandHandler CreateParserChain()
    {
        var connectModeTypeHandler = new ConnectModeTypeHandler();
        var connectCommandHandler = new ConnectCommandHandler(connectModeTypeHandler);

        var disconnectCommandHandler = new DisconnectCommandHandler();

        var fileShowOutputModeHandler = new FileShowOutputModeHandler();
        var fileShowCommandHandler = new FileShowCommandHandler(fileShowOutputModeHandler);

        fileShowCommandHandler.AddNext(new FileDeleteCommandHandler());
        fileShowCommandHandler.AddNext(new FileMoveCommandHandler());
        fileShowCommandHandler.AddNext(new FileCopyCommandHandler());
        fileShowCommandHandler.AddNext(new FileRenameCommandHandler());

        var fileCommandHandler = new FileCommandHandler(fileShowCommandHandler);

        var treeListModeHandler = new TreeListDepthModeCommandHandler();
        var treeTypeListCommandHandler = new TreeTypeListDirectoryCommandHandler(treeListModeHandler);

        treeTypeListCommandHandler.AddNext(new TreeTypeGoToCommandHandler());

        var treeCommandHandler = new TreeCommandHandler(treeTypeListCommandHandler);

        connectCommandHandler
            .AddNext(disconnectCommandHandler)
            .AddNext(fileCommandHandler)
            .AddNext(treeCommandHandler);

        return connectCommandHandler;
    }
}