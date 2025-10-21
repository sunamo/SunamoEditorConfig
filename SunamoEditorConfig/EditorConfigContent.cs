// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoEditorConfig;

public class EditorConfigContent(RootBlock rootBlock, List<MascBlock> mascBlocks)
{
    public RootBlock RootBlock { get; set; } = rootBlock;
    public List<MascBlock> MascBlocks { get; set; } = mascBlocks;

    public override string ToString()
    {
        var stringBuilder = new StringBuilder();

        stringBuilder.AppendLine(RootBlock.ToString());

        foreach (var block in MascBlocks) stringBuilder.AppendLine(block.ToString());

        return stringBuilder.ToString();
    }
}