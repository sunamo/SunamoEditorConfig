using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SunamoEditorConfig.Tests
{
    [TestClass]
    public class EditorConfigHelperTests
    {
        private const string Nl = "\n";

        [TestMethod]
        public void SingleMascBlock()
        {
            var content = @"root = true

[*]
end_of_line = lf";

            if (Environment.NewLine != Nl) content = content.Replace(Environment.NewLine, Nl);

            var parsed = EditorConfigHelper.Deserialize(null, content);

            if (parsed.Exception != null) throw new Exception(parsed.Exception);

            var serialized = EditorConfigHelper.Serialize(null, parsed.Result, Nl);

            Assert.AreEqual(content, serialized);
        }

        [TestMethod]
        public void TwoMascBlocks()
        {
            var content = @"root = true

[*]
end_of_line = lf

[*.cs]
end_of_line = crlf";

            if (Environment.NewLine != Nl) content = content.Replace(Environment.NewLine, Nl);

            var parsed = EditorConfigHelper.Deserialize(null, content);

            if (parsed.Exception != null) throw new Exception(parsed.Exception);

            var serialized = EditorConfigHelper.Serialize(null, parsed.Result, Nl);

            Assert.AreEqual(content, serialized);
        }

        [TestMethod]
        public void NoMascBlocks()
        {
            var content = @"root = true";

            if (Environment.NewLine != Nl) content = content.Replace(Environment.NewLine, Nl);

            var parsed = EditorConfigHelper.Deserialize(null, content);

            if (parsed.Exception != null) throw new Exception(parsed.Exception);

            var serialized = EditorConfigHelper.Serialize(null, parsed.Result, Nl);

            Assert.AreEqual(content, serialized);
        }
    }
}