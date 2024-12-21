using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.ConnectCommands;

[GenerateBuilder]
public partial record ConnectCommandArguments(FileSystemModes? Mode, string Path);