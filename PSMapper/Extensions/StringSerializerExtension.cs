namespace PSMapper.Extensions;

public static class StringParserExtension
{
    /// <summary>
    /// Static extension method for split row with any spaces
    /// </summary>
    /// <param name="row"></param>
    /// <returns></returns>
    public static string[] SplitRow(this string row)
    {
        return row.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
    }
}