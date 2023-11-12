namespace Rayzin.Tests;

public static class Utils
{
    public static string[] SplitLines(string input)
    {
        using var reader = new StringReader(input);
        var result = new List<string>();
        while (reader.ReadLine() is { } s)
            result.Add(s);

        return result.ToArray();
    }
}