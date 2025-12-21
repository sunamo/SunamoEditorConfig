namespace SunamoEditorConfig;

public static class EditorConfigHelper
{
    public static string Serialize(string path, EditorConfigContent content, string newLine)
    {
        var serialized = content.ToString();

        if (Environment.NewLine != newLine) serialized = serialized.Replace(Environment.NewLine, newLine);

        serialized = serialized.Trim();

        if (path != null) File.WriteAllText(path, serialized);

        return serialized;
    }

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