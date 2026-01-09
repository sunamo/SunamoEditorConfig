// variables names: ok
namespace SunamoEditorConfig;

/// <summary>
/// Represents a single key-value definition in an EditorConfig file (e.g., "indent_style = space")
/// </summary>
public class Definition
{
    /// <summary>
    /// Initializes a new instance of the Definition class
    /// </summary>
    /// <param name="key">The setting key (e.g., "indent_style")</param>
    /// <param name="value">The setting value (e.g., "space")</param>
    public Definition(string key, string value)
    {
        Key = key;
        Value = value;
    }

    /// <summary>
    /// Gets or sets the setting key
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// Gets or sets the setting value
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Converts the definition to its string representation in EditorConfig format (key=value)
    /// </summary>
    /// <returns>The EditorConfig formatted string</returns>
    public override string ToString()
    {
        return Key + "=" + Value;
    }
}