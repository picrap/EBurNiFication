// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Parser;
    using Symbols;

    [TestClass]
    public class SymbolTests
    {
        [TestMethod]
        public void ValidFirstTerminalString()
        {
            var s = "'dude'";
            Tokenizer tp = new TextTokenizer(s);
            Assert.IsTrue(TerminalString.Instance.TryParse(tp));
        }

        [TestMethod]
        public void InvalidFirstTerminalString()
        {
            var s = "'unfinished business";
            Tokenizer tp = new TextTokenizer(s);
            Assert.IsFalse(TerminalString.Instance.TryParse(tp));
        }

        [TestMethod]
        public void ValidSecondTerminalString()
        {
            var s = "\"double dude\"";
            Tokenizer tp = new TextTokenizer(s);
            Assert.IsTrue(TerminalString.Instance.TryParse(tp));
        }

        [TestMethod]
        public void InvalidSecondTerminalString()
        {
            var s = "\"unfinished double business";
            Tokenizer tp = new TextTokenizer(s);
            Assert.IsFalse(TerminalString.Instance.TryParse(tp));
        }

        [TestMethod]
        public void ValidInteger()
        {
            var s = "1234";
            Tokenizer tp = new TextTokenizer(s);
            Assert.IsTrue(Integer.Instance.TryParse(tp));
        }

        [TestMethod]
        public void ValidIntegerWithTrailing()
        {
            var s = "5678a";
            Tokenizer tp = new TextTokenizer(s);
            Assert.IsTrue(Integer.Instance.TryParse(tp));
        }

        [TestMethod]
        public void InvalidIntegerWithTrailing()
        {
            var s = "ijk";
            Tokenizer tp = new TextTokenizer(s);
            Assert.IsFalse(Integer.Instance.TryParse(tp));
        }

        [TestMethod]
        public void MetaIdentifierIntegerWithTrailing()
        {
            var s = "q1";
            Tokenizer tp = new TextTokenizer(s);
            Assert.IsTrue(MetaIdentifier.Instance.TryParse(tp));
        }
    }
}
