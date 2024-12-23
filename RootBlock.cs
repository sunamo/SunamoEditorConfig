namespace SunamoEditorConfig;

public class RootBlock
{


    public List<Definition> Definitions { get; set; } = [];

    /// <summary>
    /// Je nutno zadat block nebo lines
    /// </summary>
    /// <param name="block"></param>
    /// <param name="lines"></param>
    /// <returns></returns>
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

    public override string ToString()
    {
        var sb = new StringBuilder();

        foreach (var definition in Definitions) sb.AppendLine(definition.ToString());

        return sb.ToString();
    }
}