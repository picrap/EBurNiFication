// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class LiteralSymbol : Symbol
    {
        public override SymbolKind Kind { get; }

        public string Literal { get; }

        public LiteralSymbol(string literal, SymbolKind symbolKind)
        {
            Literal = literal;
            Kind = symbolKind;
        }

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return parser.TryRead(Literal);
        }
    }
}