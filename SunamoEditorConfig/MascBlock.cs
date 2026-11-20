namespace SunamoEditorConfig;

/// <summary>
/// Represents the masc block type.
/// </summary>
public class MascBlock : RootBlock
{
    /// <summary>
    /// Initializes a new instance of the masc block class.
    /// </summary>
    /// <param name="validFor">The valid for.</param>
    /// <param name="definitions">The definitions.</param>
    public MascBlock(string validFor, List<Definition> definitions) : base()
    {
        this.validFor = validFor;
        Definitions = definitions;
    }

    private string validFor { get; set; }

    /// <summary>
    /// Is line with masc.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The is line with masc result.</returns>
    public static bool IsLineWithMasc(string text)
    {
        text = text.Trim();
        return text.StartsWith('[') && text.EndsWith(']');
    }

    /// <summary>
    /// Parse.
    /// </summary>
    /// <param name="block">The block.</param>
    /// <returns>The parse result.</returns>
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
    /// To string.
    /// </summary>
    /// <returns>The to string result.</returns>
    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine($"[{validFor}]");

        foreach (var definition in Definitions) stringBuilder.AppendLine(definition.ToString());

        return stringBuilder.ToString();
    }
}
