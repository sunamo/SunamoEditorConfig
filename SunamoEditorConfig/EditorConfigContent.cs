namespace SunamoEditorConfig;

public class EditorConfigContent(RootBlock rootBlock, List<MascBlock> mascBlocks)
{
    public RootBlock RootBlock { get; set; } = rootBlock;
    public List<MascBlock> MascBlocks { get; set; } = mascBlocks;

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine(RootBlock.ToString());

        foreach (var block in MascBlocks) sb.AppendLine(block.ToString());

        return sb.ToString();
    }
}