// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Parsing;
    using Symbols;

    [TestClass]
    public class SyntaxTests
    {
        [TestMethod]
        public void SimpleDefinition()
        {
            var s = "a='ah';";
            var parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, Syntax.Instance).Token;
        }

        [TestMethod]
        public void SimpleDefinitionWithGaps()
        {
            var s = "a = 'ah' ;";
            var parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, Syntax.Instance).Token;
        }
    }
}
