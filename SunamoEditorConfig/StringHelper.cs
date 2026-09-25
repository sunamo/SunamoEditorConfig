namespace SunamoEditorConfig;

/// <summary>
/// Provides string manipulation helper methods for EditorConfig parsing
/// </summary>
public static class StringHelper
{
    private const string NewLine = "\n";
    private const string CarriageReturnNewLine = "\r\n";

    /// <summary>
    /// Splits text into lines using both Unix (\n) and Windows (\r\n) line endings
    /// </summary>
    /// <param name="text">The text to split into lines</param>
    /// <returns>A list of lines from the text</returns>
    public static List<string> GetLines(string text)
    {
        return text.Split(new[] { NewLine, CarriageReturnNewLine }, StringSplitOptions.None).ToList();
    }

    /// <summary>
    /// Splits text by a delimiter string
    /// </summary>
    /// <param name="text">The text to split</param>
    /// <param name="delimiter">The delimiter to split by</param>
    /// <returns>A list of split parts</returns>
    public static List<string> Split(string text, string delimiter)
    {
        return text.Split(new[] { delimiter }, StringSplitOptions.None).ToList();
    }

    /// <summary>
    /// Extracts the substring between the first and last character (removes first and last char)
    /// </summary>
    /// <param name="text">The text to extract from</param>
    /// <returns>The substring with first and last characters removed</returns>
    public static string BetweenFirstAndSecondChar(string text)
    {
        return text.Substring(0, text.Length - 1).Substring(1);
    }
}