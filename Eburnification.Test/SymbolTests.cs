﻿// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Test
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Parsing;
    using Symbols;
    using Symbols.Ebnf;

    [TestClass]
    public class SymbolTests
    {
        [TestMethod]
        public void ValidFirstTerminalString()
        {
            var s = "'dude'";
            Parser parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, TerminalString.Instance).Tokens?.Single();
            Assert.IsNotNull(token);
            Assert.IsTrue(token.Symbol is TerminalString);
            Assert.AreEqual(s, token.Value);
        }

        [TestMethod]
        public void InvalidFirstTerminalString()
        {
            var s = "'unfinished business";
            Parser parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, TerminalString.Instance).Tokens?.Single();
            Assert.IsNull(token);
        }

        [TestMethod]
        public void ValidSecondTerminalString()
        {
            var s = "\"double dude\"";
            Parser parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, TerminalString.Instance).Tokens?.Single();
            Assert.IsNotNull(token);
            Assert.IsTrue(token.Symbol is TerminalString);
            Assert.AreEqual(s, token.Value);
        }

        [TestMethod]
        public void InvalidSecondTerminalString()
        {
            var s = "\"unfinished double business";
            Parser parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, TerminalString.Instance).Tokens?.Single();
            Assert.IsNull(token);
        }

        [TestMethod]
        public void ValidInteger()
        {
            var s = "1234";
            Parser parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, Integer.Instance).Tokens?.Single();
            Assert.IsNotNull(token);
            Assert.IsTrue(token.Symbol is Integer);
            Assert.AreEqual(s, token.Value);
        }

        [TestMethod]
        public void ValidIntegerWithTrailing()
        {
            var s = "5678a";
            Parser parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, Integer.Instance).Tokens?.Single();
            Assert.IsNotNull(token);
            Assert.IsTrue(token.Symbol is Integer);
            Assert.AreEqual("5678", token.Value);
        }

        [TestMethod]
        public void InvalidIntegerWithTrailing()
        {
            var s = "ijk";
            Parser parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, Integer.Instance).Tokens?.Single();
            Assert.IsNull(token);
        }

        [TestMethod]
        public void MetaIdentifierIntegerWithTrailing()
        {
            var s = "q1";
            Parser parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, MetaIdentifier.Instance).Tokens?.Single();
            Assert.IsNotNull(token);
            Assert.IsTrue(token.Symbol is MetaIdentifier);
            Assert.AreEqual(s, token.Value);
        }
    }
}
