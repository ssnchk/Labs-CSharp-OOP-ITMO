namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ModeParsers;

public abstract class FlagParserBase<TBuilder> : IFlagParser<TBuilder>
{
    protected IFlagParser<TBuilder>? Next { get; private set; }

    public IFlagParser<TBuilder> AddNext(IFlagParser<TBuilder> parser)
    {
        if (Next is null)
        {
            Next = parser;
        }
        else
        {
            Next.AddNext(parser);
        }

        return this;
    }

    public abstract TBuilder? Handle(IEnumerator<string> request, TBuilder argumentBuilder);
}