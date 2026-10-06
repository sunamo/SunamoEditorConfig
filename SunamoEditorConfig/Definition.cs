namespace SunamoEditorConfig;

public class Definition
{
    public Definition(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public string Key { get; set; }

    public string Value { get; set; }

    /// <summary>
    /// Converts the definition to its string representation in EditorConfig format (key=value)
    /// </summary>
    /// <returns>The EditorConfig formatted string</returns>
    public override string ToString() => $"{Key}={Value}";
}