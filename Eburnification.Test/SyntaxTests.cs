// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Parsing;
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
        public void SpecialSequence()
        {
            const string s = "a=? dude! ?;";
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(s);
            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void Comment()
        {
            const string s = "(* something here *) one='1';";
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(s);
            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void NewSyntax()
        {
            const string s = @"
assignment = identifier, assignmentsymbol, anyvalue;

space = ' ';
assignmentcharacter = '=' | ':';
assignmentsymbol = {space}, assignmentcharacter, {space};

identifier = {identifierchar};
identifierchar = lletter | uletter | '-' | digit;

anyvalue = integer | boolean;

integer = {digit};

true =  'true' |'yes'|'on' |'1';
false = 'false'|'no' |'off'|'0';
boolean = true|false;

digit =   '0'|'1'|'2'|'3'|'4'|'5'|'6'|'7'|'8'|'9';
lletter = 'a'|'b'|'c'|'d'|'e'|'f'|'g'|'h'|'i'|'j'|'k'|'l'|'m'|'n'|'o'|'p'|'q'|'r'|'s'|'t'|'u'|'v'|'w'|'x'|'y'|'z';
uletter = 'A'|'B'|'C'|'D'|'E'|'F'|'G'|'H'|'I'|'J'|'K'|'L'|'M'|'N'|'O'|'P'|'Q'|'R'|'S'|'T'|'U'|'V'|'W'|'X'|'Y'|'Z';
";
            var tokenizer = new Tokenizer();
            var token = tokenizer.Parse(s);
            Assert.IsNotNull(token);

            var sb = new SyntaxBuilder();
            var newSyntax = sb.Build(token);

            const string s2 = @"A-1 : 123";

            var tokenizer2 = new Tokenizer();
            var token2 = tokenizer2.Parse(s2, newSyntax);
        }
    }
}
