// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoEditorConfig;

public static class ListHelper
{
    public static List<string> Trim(List<string> list)
    {
        for (var i = 0; i < list.Count; i++) list[i] = list[i].Trim();

        return list;
    }
}