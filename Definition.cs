namespace SunamoEditorConfig;
public class Definition
{
    public string Key { get; set; }
    public string Value { get; set; }

    public override string ToString()
    {
        return Key + "=" + Value;
    }
}