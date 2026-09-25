namespace SunamoEditorConfig;

public static class StringHelper
{
    private const string NewLine = "\n";
    private const string CarriageReturnNewLine = "\r\n";

    public static List<string> GetLines(string text)
    {
        return text.Split(new[] { NewLine, CarriageReturnNewLine }, StringSplitOptions.None).ToList();
    }

    public static List<string> Split(string text, string delimiter)
    {
        return text.Split(new[] { delimiter }, StringSplitOptions.None).ToList();
    }

    public static string BetweenFirstAndSecondChar(string text)
    {
        return text.Substring(0, text.Length - 1).Substring(1);
    }
}
