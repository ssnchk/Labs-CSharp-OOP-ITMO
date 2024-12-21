namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers.ModeParsers;

public interface IFlagParser<TBuilder>
{
    IFlagParser<TBuilder> AddNext(IFlagParser<TBuilder> parser);

    TBuilder? Handle(IEnumerator<string> request, TBuilder argumentBuilder);
}