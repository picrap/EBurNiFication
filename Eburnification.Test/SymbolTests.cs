// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Parsing;
    using Symbols;

    [TestClass]
    public class SymbolTests
    {
        [TestMethod]
        public void ValidFirstTerminalString()
        {
            var s = "'dude'";
            Parser tp = new TextParser(s);
            Assert.IsTrue(TerminalString.Instance.TryParse(tp));
        }

        [TestMethod]
        public void InvalidFirstTerminalString()
        {
            var s = "'unfinished business";
            Parser tp = new TextParser(s);
            Assert.IsFalse(TerminalString.Instance.TryParse(tp));
        }

        [TestMethod]
        public void ValidSecondTerminalString()
        {
            var s = "\"double dude\"";
            Parser tp = new TextParser(s);
            Assert.IsTrue(TerminalString.Instance.TryParse(tp));
        }

        [TestMethod]
        public void InvalidSecondTerminalString()
        {
            var s = "\"unfinished double business";
            Parser tp = new TextParser(s);
            Assert.IsFalse(TerminalString.Instance.TryParse(tp));
        }

        [TestMethod]
        public void ValidInteger()
        {
            var s = "1234";
            Parser tp = new TextParser(s);
            Assert.IsTrue(Integer.Instance.TryParse(tp));
        }

        [TestMethod]
        public void ValidIntegerWithTrailing()
        {
            var s = "5678a";
            Parser tp = new TextParser(s);
            Assert.IsTrue(Integer.Instance.TryParse(tp));
        }

        [TestMethod]
        public void InvalidIntegerWithTrailing()
        {
            var s = "ijk";
            Parser tp = new TextParser(s);
            Assert.IsFalse(Integer.Instance.TryParse(tp));
        }

        [TestMethod]
        public void MetaIdentifierIntegerWithTrailing()
        {
            var s = "q1";
            Parser tp = new TextParser(s);
            Assert.IsTrue(MetaIdentifier.Instance.TryParse(tp));
        }
    }
}
