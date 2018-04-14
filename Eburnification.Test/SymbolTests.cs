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
            var ts = new TerminalString();
            Assert.IsTrue(ts.TryParse(ref tp));
        }

        [TestMethod]
        public void InvalidFirstTerminalString()
        {
            var s = "'unfinished business";
            Tokenizer tp = new TextTokenizer(s);
            var ts = new TerminalString();
            Assert.IsFalse(ts.TryParse(ref tp));
        }

        [TestMethod]
        public void ValidSecondTerminalString()
        {
            var s = "\"double dude\"";
            Tokenizer tp = new TextTokenizer(s);
            var ts = new TerminalString();
            Assert.IsTrue(ts.TryParse(ref tp));
        }

        [TestMethod]
        public void InvalidSecondTerminalString()
        {
            var s = "\"unfinished double business";
            Tokenizer tp = new TextTokenizer(s);
            var ts = new TerminalString();
            Assert.IsFalse(ts.TryParse(ref tp));
        }
    }
}