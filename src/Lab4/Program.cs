using Itmo.ObjectOrientedProgramming.Lab4.OutputRunners;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class Program
{
    public static void Main()
    {
        var runner = new OutputRunner(ParserCreator.CreateParser(), new ArgumentSeparator(" "));
        runner.Run();
    }
}