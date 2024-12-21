using Itmo.ObjectOrientedProgramming.Lab4;
using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands;
using Xunit;

namespace Lab4.Tests;

public class FileSystemTests
{
    [Fact]
    public void ConnectCommandTest()
    {
        // Arrange
        ICommandHandler chain = ParserCreator.CreateParser();

        List<string> requestForConnect = ["connect", "some_address", "-m", "local"];
        using IEnumerator<string> requestForConnectEnumerator = requestForConnect.GetEnumerator();
        requestForConnectEnumerator.MoveNext();

        List<string> requestForNull = ["connect", "some_address", "local"];
        using IEnumerator<string> requestForNullEnumerator = requestForNull.GetEnumerator();
        requestForNullEnumerator.MoveNext();

        // Act
        ICommand? connectCommand = chain.Handle(requestForConnectEnumerator);
        ICommand? nullCommand = chain.Handle(requestForNullEnumerator);

        // Assert
        Assert.IsType<LocalConnectCommand>(connectCommand);

        Assert.Null(nullCommand);
    }

    [Fact]
    public void DisconnectCommandTest()
    {
        // Arrange
        ICommandHandler chain = ParserCreator.CreateParser();

        List<string> request = ["disconnect"];
        using IEnumerator<string> requestEnumerator = request.GetEnumerator();
        requestEnumerator.MoveNext();

        // Act
        ICommand? disconnectCommand = chain.Handle(requestEnumerator);

        // Assert
        Assert.IsType<DisconnectCommand>(disconnectCommand);
    }

    [Fact]
    public void TreeGoToCommandTest()
    {
        // Arrange
        ICommandHandler chain = ParserCreator.CreateParser();

        List<string> request =
        [
            "connect", @"C:\Users\30050\RiderProjects\ssnchk\tests\Lab4.Tests\sample_folder", "-m", "local",
            "tree", "goto", "second_inner_folder"
        ];
        using IEnumerator<string> requestEnumerator = request.GetEnumerator();
        requestEnumerator.MoveNext();

        // Act
        chain.Handle(requestEnumerator);
        requestEnumerator.MoveNext();
        ICommand? treeGoToCommand = chain.Handle(requestEnumerator);

        // Assert
        Assert.IsType<TreeGoToCommand>(treeGoToCommand);
    }

    [Fact]
    public void TreeListCommandTest()
    {
        // Arrange
        ICommandHandler chain = ParserCreator.CreateParser();

        List<string> request =
        [
            "connect", @"C:\Users\30050\RiderProjects\ssnchk\tests\Lab4.Tests\sample_folder", "-m", "local",
            "tree", "list", "-d", "2"
        ];
        using IEnumerator<string> requestEnumerator = request.GetEnumerator();
        requestEnumerator.MoveNext();

        // Act
        chain.Handle(requestEnumerator);
        requestEnumerator.MoveNext();
        ICommand? treeListCommand = chain.Handle(requestEnumerator);

        // Assert
        Assert.IsType<ConsoleTreeListCommand>(treeListCommand);
    }

    [Fact]
    public void FileShowCommandTest()
    {
        // Arrange
        ICommandHandler chain = ParserCreator.CreateParser();

        List<string> request =
        [
            "connect", @"C:\Users\30050\RiderProjects\ssnchk\tests\Lab4.Tests\sample_folder", "-m", "local",
            "file", "show", "file.txt", "-m", "console"
        ];
        using IEnumerator<string> requestEnumerator = request.GetEnumerator();
        requestEnumerator.MoveNext();

        // Act
        chain.Handle(requestEnumerator);
        requestEnumerator.MoveNext();
        ICommand? fileShowCommand = chain.Handle(requestEnumerator);

        // Assert
        Assert.IsType<ConsoleFileShowCommand>(fileShowCommand);
    }

    [Fact]
    public void FileCopyCommandTest()
    {
        // Arrange
        ICommandHandler chain = ParserCreator.CreateParser();

        List<string> request =
        [
            "connect", @"C:\Users\30050\RiderProjects\ssnchk\tests\Lab4.Tests\sample_folder", "-m", "local",
            "file", "copy", "file.txt", "new_file.txt"
        ];
        using IEnumerator<string> requestEnumerator = request.GetEnumerator();
        requestEnumerator.MoveNext();

        // Act
        chain.Handle(requestEnumerator);
        requestEnumerator.MoveNext();
        ICommand? fileCopyCommand = chain.Handle(requestEnumerator);

        // Assert
        Assert.IsType<FileCopyCommand>(fileCopyCommand);
    }

    [Fact]
    public void FileDeleteCommandTest()
    {
        // Arrange
        ICommandHandler chain = ParserCreator.CreateParser();

        List<string> request =
        [
            "connect", @"C:\Users\30050\RiderProjects\ssnchk\tests\Lab4.Tests\sample_folder", "-m", "local",
            "file", "delete", "any_file.txt"
        ];
        using IEnumerator<string> requestEnumerator = request.GetEnumerator();
        requestEnumerator.MoveNext();

        // Act
        chain.Handle(requestEnumerator);
        requestEnumerator.MoveNext();
        ICommand? fileDeleteCommand = chain.Handle(requestEnumerator);

        // Assert
        Assert.IsType<FileDeleteCommand>(fileDeleteCommand);
    }

    [Fact]
    public void FileRenameCommandTest()
    {
        // Arrange
        ICommandHandler chain = ParserCreator.CreateParser();

        List<string> request =
        [
            "connect", @"C:\Users\30050\RiderProjects\ssnchk\tests\Lab4.Tests\sample_folder", "-m", "local",
            "file", "rename", "any_file.txt", "new_file.txt"
        ];
        using IEnumerator<string> requestEnumerator = request.GetEnumerator();
        requestEnumerator.MoveNext();

        // Act
        chain.Handle(requestEnumerator);
        requestEnumerator.MoveNext();
        ICommand? fileRenameCommand = chain.Handle(requestEnumerator);

        // Assert
        Assert.IsType<FileRenameCommand>(fileRenameCommand);
    }

    [Fact]
    public void FileMoveCommandTest()
    {
        // Arrange
        ICommandHandler chain = ParserCreator.CreateParser();

        List<string> request =
        [
            "connect", @"C:\Users\30050\RiderProjects\ssnchk\tests\Lab4.Tests\sample_folder", "-m", "local",
            "file", "move", "any_file.txt", "new_file.txt"
        ];
        using IEnumerator<string> requestEnumerator = request.GetEnumerator();
        requestEnumerator.MoveNext();

        // Act
        chain.Handle(requestEnumerator);
        requestEnumerator.MoveNext();
        ICommand? fileMoveCommand = chain.Handle(requestEnumerator);

        // Assert
        Assert.IsType<FileMoveCommand>(fileMoveCommand);
    }
}