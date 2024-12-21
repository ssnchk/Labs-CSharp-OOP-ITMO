using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ConnectModeCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.FileCommandHandlers.FileShowModeCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeCommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeCommandHandlers.TreeListModeCommandHandlers;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class ParserCreator
{
    public static ICommandHandler CreateParser()
    {
        var connectModeTypeHandler = new ConnectModeTypeParser();
        var connectCommandHandler = new ConnectCommandParser(connectModeTypeHandler);

        var disconnectCommandHandler = new DisconnectCommandParser();

        var fileShowOutputModeHandler = new FileShowOutputModeParser();
        var fileShowCommandHandler = new FileShowCommandParser(fileShowOutputModeHandler);

        fileShowCommandHandler.AddNext(new FileDeleteCommandParser());
        fileShowCommandHandler.AddNext(new FileMoveCommandParser());
        fileShowCommandHandler.AddNext(new FileCopyCommandParser());
        fileShowCommandHandler.AddNext(new FileRenameCommandParser());

        var fileCommandHandler = new FileCommandParser(fileShowCommandHandler);

        var treeListModeHandler = new TreeListDepthModeCommandParser();
        var treeTypeListCommandHandler = new TreeListDirectoryCommandParser(treeListModeHandler);

        treeTypeListCommandHandler.AddNext(new TreeGoToCommandParser());

        var treeCommandHandler = new TreeCommandParser(treeTypeListCommandHandler);

        connectCommandHandler
            .AddNext(disconnectCommandHandler)
            .AddNext(fileCommandHandler)
            .AddNext(treeCommandHandler);

        return connectCommandHandler;
    }
}