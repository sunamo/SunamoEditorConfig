namespace SunamoEditorConfig;

/// <summary>
/// Editor config content.
/// </summary>
/// <param name="rootBlock">The root block.</param>
/// <param name="mascBlocks">The masc blocks.</param>
/// <returns>The editor config content result.</returns>
public class EditorConfigContent(RootBlock rootBlock, List<MascBlock> mascBlocks)
{
    /// <summary>
    /// Gets or sets the root block.
    /// </summary>
    public RootBlock RootBlock { get; set; } = rootBlock;

    /// <summary>
    /// Gets or sets the masc blocks.
    /// </summary>
    public List<MascBlock> MascBlocks { get; set; } = mascBlocks;

    /// <summary>
    /// To string.
    /// </summary>
    /// <returns>The to string result.</returns>
    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine(RootBlock.ToString());

        foreach (var block in MascBlocks) stringBuilder.AppendLine(block.ToString());

        return stringBuilder.ToString();
    }
}
