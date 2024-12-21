using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public abstract class CommandParserBase : ICommandHandler
{
    protected ICommandHandler? Next { get; private set; }

    public ICommandHandler AddNext(ICommandHandler handler)
    {
        if (Next is null)
        {
            Next = handler;
        }
        else
        {
            Next.AddNext(handler);
        }

        return this;
    }

    public abstract ICommand? Handle(IEnumerator<string> request);
}