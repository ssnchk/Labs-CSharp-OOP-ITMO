using Itmo.ObjectOrientedProgramming.Lab4.ValueTypes;
using SourceKit.Generators.Builder.Annotations;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands;

[GenerateBuilder]
public partial record TreeListArguments(TreeDepth? Depth);