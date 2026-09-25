namespace SunamoEditorConfig;

/// <summary>
/// Provides helper methods for serializing and deserializing EditorConfig files
/// </summary>
public static class EditorConfigHelper
{
    /// <summary>
    /// Serializes EditorConfigContent to a string and optionally writes it to a file
    /// </summary>
    /// <param name="path">The file path to write to (can be null to skip file writing)</param>
    /// <param name="content">The EditorConfigContent to serialize</param>
    /// <param name="newLine">The line ending to use in the serialized output</param>
    /// <returns>The serialized EditorConfig string</returns>
    public static string Serialize(string path, EditorConfigContent content, string newLine)
    {
        var serialized = content.ToString();

        if (Environment.NewLine != newLine) serialized = serialized.Replace(Environment.NewLine, newLine);

        serialized = serialized.Trim();

        if (path != null) File.WriteAllText(path, serialized);

        return serialized;
    }

    /// <summary>
    /// Deserializes an EditorConfig file from a path or text content
    /// </summary>
    /// <param name="path">The file path to read from</param>
    /// <param name="text">The text content to parse (if null, reads from path)</param>
    /// <returns>A result containing the parsed EditorConfigContent or an exception if parsing fails</returns>
    public static ResultWithExceptionEditorConfig<EditorConfigContent> Deserialize(string path, string? text)
    {
        text ??= File.ReadAllText(path);

        var lines = StringHelper.GetLines(text);

        var blocks = new List<string>();

        var stringBuilder = new StringBuilder();

        foreach (var line in lines)
        {
            if (MascBlock.IsLineWithMasc(line))
            {
                blocks.Add(stringBuilder.ToString());

                stringBuilder = new StringBuilder();
            }

            stringBuilder.AppendLine(line);
        }

        blocks.Add(stringBuilder.ToString());

        RootBlock? rootBlock = null;
        var mascBlocks = new List<MascBlock>();

        foreach (var block in blocks)
            if (MascBlock.IsLineWithMasc(StringHelper.GetLines(block).First()))
            {
                var mascBlock = MascBlock.Parse(block);
                if (mascBlock.Exception != null)
                    return new ResultWithExceptionEditorConfig<EditorConfigContent>(mascBlock.Exception);

                mascBlocks.Add(mascBlock.Result!);
            }
            else
            {
                var rootBlockResult = RootBlock.Parse(block, null);

                if (rootBlockResult.Exception != null)
                    return new ResultWithExceptionEditorConfig<EditorConfigContent>(rootBlockResult.Exception);

                rootBlock = rootBlockResult.Result!;
            }

        if (rootBlock == null)
        {
            throw new Exception($"{nameof(rootBlock)} is null");
        }

        return new ResultWithExceptionEditorConfig<EditorConfigContent>(new EditorConfigContent(rootBlock, mascBlocks));
    }
}