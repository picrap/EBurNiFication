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
            Parser parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, TerminalString.Instance);
            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void InvalidFirstTerminalString()
        {
            var s = "'unfinished business";
            Parser parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, TerminalString.Instance);
            Assert.IsNull(token);
        }

        [TestMethod]
        public void ValidSecondTerminalString()
        {
            var s = "\"double dude\"";
            Parser parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, TerminalString.Instance);
            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void InvalidSecondTerminalString()
        {
            var s = "\"unfinished double business";
            Parser parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, TerminalString.Instance);
            Assert.IsNull(token);
        }

        [TestMethod]
        public void ValidInteger()
        {
            var s = "1234";
            Parser parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, Integer.Instance);
            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void ValidIntegerWithTrailing()
        {
            var s = "5678a";
            Parser parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, Integer.Instance);
            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void InvalidIntegerWithTrailing()
        {
            var s = "ijk";
            Parser parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, Integer.Instance);
            Assert.IsNull(token);
        }

        [TestMethod]
        public void MetaIdentifierIntegerWithTrailing()
        {
            var s = "q1";
            Parser parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, MetaIdentifier.Instance);
            Assert.IsNotNull(token);
        }
    }
}
