namespace SunamoEditorConfig;
public class Definition
{
    public Definition(string key, string value)
    {
        Key = key;
        Value = value;
    }

    public string Key { get; private set; }
    public string Value { get; private set; }

    public override string ToString()
    {
        return Key + "=" + Value;
    }
}