using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.FileCommands;

[GenerateBuilder]
public partial record FileShowArguments(FileShowModes? Mode, string Path);