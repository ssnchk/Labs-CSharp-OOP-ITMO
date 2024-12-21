namespace Itmo.ObjectOrientedProgramming.Lab4.OutputRunners;

public class ArgumentSeparator
{
    private readonly char[] _separator;

    public ArgumentSeparator(string separator)
    {
        _separator = separator.ToCharArray();
    }

    public IEnumerator<string> Separate(string? input)
    {
        if (input is null)
            return new List<string>().GetEnumerator();

        string[] separatedString = input.Split(_separator, StringSplitOptions.RemoveEmptyEntries);

        return new List<string>(separatedString).GetEnumerator();
    }
}