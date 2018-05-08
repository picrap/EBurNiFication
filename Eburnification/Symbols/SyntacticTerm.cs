// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class SyntacticTerm : Symbol<SyntacticTerm>
    {
        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseAny(parser, ParseAny(tokenizer, parser));
        }

        private IEnumerable<ParsingResult> ParseAny(Tokenizer tokenizer, Parser parser)
        {
            yield return tokenizer.ParseAll(parser, SyntacticFactor.Instance, ExceptSymbol.Instance, SyntacticException.Instance);
            yield return tokenizer.Parse(parser, SyntacticFactor.Instance);
        }
    }
}