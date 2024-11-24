using Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ModeParsers;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.TreeCommands;
using Itmo.ObjectOrientedProgramming.Lab4.ValueTypes;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.TreeCommandHandlers.TreeListModeCommandHandlers;

public class TreeListDepthModeCommandParser : FlagParserBase<TreeListArguments.Builder>
{
    public override TreeListArguments.Builder? Handle(
        IEnumerator<string> request,
        TreeListArguments.Builder argumentBuilder)
    {
        if (request.Current is not "-d")
            return Next?.Handle(request, argumentBuilder);

        if (request.MoveNext() is false)
            return null;

        int depth = int.Parse(request.Current);

        argumentBuilder.WithDepth(new TreeDepth(depth));

        return argumentBuilder;
    }
}