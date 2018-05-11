// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections;
    using Parsing;

    public class LiteralSymbol : Symbol
    {
        public override bool IsGapFreeSymbol => true;

        public override SymbolKind Kind => SymbolKind.Literal;

        public string Literal { get; }

        public LiteralSymbol(string literal)
        {
            Literal = literal;
        }

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return parser.TryRead(Literal);
        }
    }
}