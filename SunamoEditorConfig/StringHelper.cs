// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoEditorConfig;
public static class StringHelper
{
    private const string N = "\n";
    private const string Nl = "\r\n";

    public static List<string> GetLines(string text)
    {
        return text.Split(new[] { N, Nl }, StringSplitOptions.None).ToList();
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