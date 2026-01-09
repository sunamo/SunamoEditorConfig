// variables names: ok
namespace SunamoEditorConfig;

/// <summary>
/// Represents the complete content of an EditorConfig file, including the root block and all MASC blocks
/// </summary>
/// <param name="rootBlock">The root configuration block with global settings</param>
/// <param name="mascBlocks">The list of MASC (Match And Settings Configuration) blocks for specific file patterns</param>
public class EditorConfigContent(RootBlock rootBlock, List<MascBlock> mascBlocks)
{
    /// <summary>
    /// Gets or sets the root configuration block with global settings
    /// </summary>
    public RootBlock RootBlock { get; set; } = rootBlock;

    /// <summary>
    /// Gets or sets the list of MASC blocks for specific file patterns
    /// </summary>
    public List<MascBlock> MascBlocks { get; set; } = mascBlocks;

    /// <summary>
    /// Converts the EditorConfigContent to its string representation in EditorConfig format
    /// </summary>
    /// <returns>The complete EditorConfig formatted string</returns>
    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine(RootBlock.ToString());

        foreach (var block in MascBlocks) stringBuilder.AppendLine(block.ToString());

        return stringBuilder.ToString();
    }
}