namespace SunamoEditorConfig;

/// <summary>
/// Represents the root configuration block in an EditorConfig file containing global settings
/// </summary>
public class RootBlock
{
    /// <summary>
    /// Gets or sets the list of configuration definitions in this block
    /// </summary>
    public List<Definition> Definitions { get; set; } = [];

    /// <summary>
    /// Parses a root block from either a block string or a list of lines. At least one parameter must be provided.
    /// </summary>
    /// <param name="block">The block string to parse (optional if lines is provided)</param>
    /// <param name="lines">The list of lines to parse (optional if block is provided)</param>
    /// <returns>A result containing the parsed RootBlock or an exception if parsing fails</returns>
    public static ResultWithExceptionEditorConfig<RootBlock> Parse(string? block, List<string>? lines)
    {
        var rootBlock = new RootBlock();

        if (lines == null)
        {
            if (block == null)
            {
                throw new Exception($"Both of {nameof(lines)} and {nameof(block)} is null");
            }
            lines = StringHelper.GetLines(block);
        }

        foreach (var line in lines)
        {
            if (line.Trim() == string.Empty) continue;
            var parts = StringHelper.Split(line, "=");

            if (parts.Count != 2)
                return new ResultWithExceptionEditorConfig<RootBlock>("Unparseable line: \"" + line + "\"");

            parts = ListHelper.Trim(parts);

            rootBlock.Definitions.Add(new Definition(parts[0], parts[1]));
        }

        return new ResultWithExceptionEditorConfig<RootBlock>(rootBlock);
    }

    /// <summary>
    /// Converts the RootBlock to its string representation in EditorConfig format
    /// </summary>
    /// <returns>The EditorConfig formatted string containing all definitions</returns>
    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        foreach (var definition in Definitions) stringBuilder.AppendLine(definition.ToString());

        return stringBuilder.ToString();
    }
}