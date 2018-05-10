// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Parsing;
    using Symbols;
    using Syntax;

    [TestClass]
    public class SyntaxTests
    {
        [TestMethod]
        public void SimpleDefinition()
        {
            const string s = "a='ah';";
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(s);
            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void SimpleDefinitionWithGaps()
        {
            const string s = "a = 'ah' ;";
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(s);
            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void DefinitionListWithGaps()
        {
            const string s = "l = 'A' | 'B';";
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(s);
            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void NewSyntax()
        {
            const string s = @"
digit = '0' | '1'|'2'|'3'|'4'|'5'|'6'|'7'|'8'|'9';
lletter = 'a'|'b'|'c'|'d'|'e'|'f'|'g'|'h'|'i'|'j'|'k'|'l'|'m'|'n'|'o'|'p'|'q'|'r'|'s'|'t'|'u'|'v'|'w'|'x'|'y'|'z';
uletter = 'A'|'B'|'C'|'D'|'E'|'F'|'G'|'H'|'I'|'J'|'K'|'L'|'M'|'N'|'O'|'P'|'Q'|'R'|'S'|'T'|'U'|'V'|'W'|'X'|'Y'|'Z';
integer = {digit};
true = 'true'|'yes'|'on'|'1';
false = 'false'|'no'|'off'|'0';
boolean = true|false;
identifierchar = lletter | uletter | '-';
identifier = {identifierchar};
anyvalue = boolean | integer;
assignment = identifier, '=', anyvalue;
";
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(s);
            Assert.IsNotNull(token);

            //var sb = new SyntaxBuilder();
            //var newSyntax = sb.Build(token);
        }
    }
}
