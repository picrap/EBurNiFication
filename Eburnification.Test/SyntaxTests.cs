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
            const string s = "a='ah';";
            var parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, Syntax.Instance).Token;
        }

        [TestMethod]
        public void SimpleDefinitionWithGaps()
        {
            const string s = "a = 'ah' ;";
            var parser = new TextParser(s);
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(parser, Syntax.Instance).Token;
        }

        [TestMethod]
        public void NewSyntax()
        {
            const string s = @"
digit = '0'|'1'|'2'|'3'|'4'|'5'|'6'|'7'|'8'|'9';
true = 'true'|'yes'|'on'|'1';
false = 'false'|'no'|'off'|'0';
boolean = true|false;
";
            var tokenizer = new Tokenizer();
            var token = tokenizer.ParseEbnf(s);
        }
    }
}
