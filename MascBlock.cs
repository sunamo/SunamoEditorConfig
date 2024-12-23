namespace SunamoEditorConfig;
public class MascBlock : RootBlock
{
    public MascBlock(string validFor, List<Definition> definitions) : base()
    {
        ValidFor = validFor;
        Definitions = definitions;
    }

    private string ValidFor { get; set; }

    public static bool IsLineWithMasc(string text)
    {
        text = text.Trim();
        return text.StartsWith('[') && text.EndsWith(']');
    }

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

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine("[" + ValidFor + "]");

        foreach (var definition in Definitions) sb.AppendLine(definition.ToString());

        return sb.ToString();
    }
}