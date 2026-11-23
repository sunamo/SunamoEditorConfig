namespace SunamoEditorConfig;

/// <summary>
/// Represents the definition type.
/// </summary>
public class Definition
{
    /// <summary>
    /// Initializes a new instance of the definition class.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public Definition(string key, string value)
    {
        Key = key;
        Value = value;
    }

    /// <summary>
    /// Gets or sets the key.
    /// </summary>
    public string Key { get; set; }

    /// <summary>
    /// Gets or sets the value.
    /// </summary>
    public string Value { get; set; }

    /// <summary>
    /// Converts the definition to its string representation in EditorConfig format (key=value)
    /// </summary>
    /// <returns>The EditorConfig formatted string</returns>
    public override string ToString() => $"{Key}={Value}";
}