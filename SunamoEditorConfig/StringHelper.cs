namespace SunamoEditorConfig;

/// <summary>
/// Represents the string helper type.
/// </summary>
public static class StringHelper
{
    private const string NewLine = "\n";
    private const string CarriageReturnNewLine = "\r\n";

    /// <summary>
    /// Get lines.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The get lines result.</returns>
    public static List<string> GetLines(string text)
    {
        return text.Split(new[] { NewLine, CarriageReturnNewLine }, StringSplitOptions.None).ToList();
    }

    /// <summary>
    /// Split.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>The split result.</returns>
    public static List<string> Split(string text, string delimiter)
    {
        return text.Split(new[] { delimiter }, StringSplitOptions.None).ToList();
    }

    /// <summary>
    /// Between first and second char.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The between first and second char result.</returns>
    public static string BetweenFirstAndSecondChar(string text)
    {
        return text.Substring(0, text.Length - 1).Substring(1);
    }
}
