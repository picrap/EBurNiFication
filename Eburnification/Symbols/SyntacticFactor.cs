// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class SyntacticFactor : Symbol<SyntacticFactor>
    {
        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseAny(parser, ParseAny(tokenizer, parser));
        }

        private IEnumerable<ParsingResult> ParseAny(Tokenizer tokenizer, Parser parser)
        {
            yield return tokenizer.ParseAll(parser, Integer.Instance, RepetitionSymbol.Instance, SyntacticPrimary.Instance);
            yield return tokenizer.Parse(parser, SyntacticPrimary.Instance);
        }
    }
}