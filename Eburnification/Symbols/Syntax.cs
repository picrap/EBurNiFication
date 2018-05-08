// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections;
    using System.Collections.Generic;
    using Parsing;

    public class Syntax : Symbol<Syntax>
    {
        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseAll(parser, ParseAll(tokenizer, parser));
        }

        private IEnumerable<ParsingResult> ParseAll(Tokenizer tokenizer, Parser parser)
        {
            yield return tokenizer.Parse(parser, GapSeparator.Instance);
            yield return tokenizer.ParseSequence(parser, SyntaxRule.Instance, 1, int.MaxValue);
            yield return tokenizer.Parse(parser, GapSeparator.Instance);
        }
    }
}