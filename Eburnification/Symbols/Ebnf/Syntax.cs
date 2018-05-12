// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using System.Collections.Generic;
    using Parsing;

    public class Syntax : Symbol<Syntax>
    {
        public override SymbolKind Kind => SymbolKind.OneOf;

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseAll(parser, ParseAll(tokenizer, parser));
        }

        private IEnumerable<ParsingResult> ParseAll(Tokenizer tokenizer, Parser parser)
        {
            tokenizer.Parse(parser, GapSeparator.Instance);
            tokenizer.Parse(parser, BracketedTextualComment.Instance);
            tokenizer.Parse(parser, GapSeparator.Instance);
            yield return tokenizer.ParseSequence(parser, SyntaxRule.Instance, 1, int.MaxValue);
            tokenizer.Parse(parser, GapSeparator.Instance);
            tokenizer.Parse(parser, BracketedTextualComment.Instance);
            tokenizer.Parse(parser, GapSeparator.Instance);
        }
    }
}