// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
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