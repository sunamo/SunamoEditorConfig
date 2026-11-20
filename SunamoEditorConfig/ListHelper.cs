namespace SunamoEditorConfig;

/// <summary>
/// Represents the list helper type.
/// </summary>
public static class ListHelper
{
    /// <summary>
    /// Trim.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The trim result.</returns>
    public static List<string> Trim(List<string> list)
    {
        for (var i = 0; i < list.Count; i++) list[i] = list[i].Trim();

        return list;
    }
}
