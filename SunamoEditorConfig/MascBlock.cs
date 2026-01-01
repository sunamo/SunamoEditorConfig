namespace SunamoEditorConfig;

/// <summary>
/// Represents a MASC (Match And Settings Configuration) block in an EditorConfig file
/// A MASC block starts with a pattern like [*.cs] and contains settings for matching files
/// </summary>
public class MascBlock : RootBlock
{
    /// <summary>
    /// Initializes a new instance of the MascBlock class
    /// </summary>
    /// <param name="validFor">The file pattern this block is valid for (e.g., "*.cs")</param>
    /// <param name="definitions">The list of settings definitions for matching files</param>
    public MascBlock(string validFor, List<Definition> definitions) : base()
    {
        this.validFor = validFor;
        Definitions = definitions;
    }

    private string validFor { get; set; }

    /// <summary>
    /// Checks if a line represents the start of a MASC block (enclosed in square brackets)
    /// </summary>
    /// <param name="text">The line text to check</param>
    /// <returns>True if the line is a MASC block header, false otherwise</returns>
    public static bool IsLineWithMasc(string text)
    {
        text = text.Trim();
        return text.StartsWith('[') && text.EndsWith(']');
    }

    /// <summary>
    /// Parses a text block into a MascBlock object
    /// </summary>
    /// <param name="block">The text block containing the MASC block definition</param>
    /// <returns>A result containing the parsed MascBlock or an exception if parsing fails</returns>
    public static ResultWithExceptionEditorConfig<MascBlock> Parse(string block)
    {
        var lines = StringHelper.GetLines(block);
        var otherLines = lines.Skip(1).ToList();

        var definitions = Parse(null, otherLines);

        if (definitions.Exception != null)
            return new ResultWithExceptionEditorConfig<MascBlock>(definitions.Exception);

        if (definitions.Result == null)
        {
            throw new Exception($"Both of {nameof(definitions.Exception)} and {nameof(definitions.Result)} is null");
        }

        return new ResultWithExceptionEditorConfig<MascBlock>(new MascBlock(StringHelper.BetweenFirstAndSecondChar(lines.First()), definitions.Result.Definitions));
    }

    /// <summary>
    /// Converts the MascBlock to its string representation in EditorConfig format
    /// </summary>
    /// <returns>The EditorConfig formatted string</returns>
    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine("[" + validFor + "]");

        foreach (var definition in Definitions) stringBuilder.AppendLine(definition.ToString());

        return stringBuilder.ToString();
    }
}