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

    public override string ToString() => $"{Key}={Value}";
}
