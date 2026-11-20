namespace SunamoEditorConfig;

/// <summary>
/// Represents the root block type.
/// </summary>
public class RootBlock
{
    /// <summary>
    /// Gets or sets the definitions.
    /// </summary>
    public List<Definition> Definitions { get; set; } = [];

    /// <summary>
    /// Parse.
    /// </summary>
    /// <param name="block">The block.</param>
    /// <param name="lines">The lines.</param>
    /// <returns>The parse result.</returns>
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
                return new ResultWithExceptionEditorConfig<RootBlock>($"Unparseable line: \"{line}\"");

            parts = ListHelper.Trim(parts);

            rootBlock.Definitions.Add(new Definition(parts[0], parts[1]));
        }

        return new ResultWithExceptionEditorConfig<RootBlock>(rootBlock);
    }

    /// <summary>
    /// To string.
    /// </summary>
    /// <typeparam name="RootBlock">The type RootBlock.</typeparam>
    /// <param name="rootBlock">The root block.</param>
    /// <returns>The to string result.</returns>
    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        foreach (var definition in Definitions) stringBuilder.AppendLine(definition.ToString());

        return stringBuilder.ToString();
    }
}
