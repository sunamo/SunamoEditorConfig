namespace SunamoEditorConfig.TestRunner
{
    internal static class Program
    {
        private static void Main()
        {
            var tests = new EditorConfigHelperTests();

            tests.SingleMascBlock();
            tests.TwoMascBlocks();
            tests.NoMascBlocks();
        }
    }
}
