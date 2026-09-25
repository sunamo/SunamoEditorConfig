namespace SunamoEditorConfig;

/// <summary>
/// Provides helper methods for list operations
/// </summary>
public static class ListHelper
{
    /// <summary>
    /// Trims all strings in the list by removing leading and trailing whitespace
    /// </summary>
    /// <param name="list">The list of strings to trim</param>
    /// <returns>The same list with all strings trimmed</returns>
    public static List<string> Trim(List<string> list)
    {
        for (var i = 0; i < list.Count; i++) list[i] = list[i].Trim();

        return list;
    }
}