// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using System.Linq;
    using Parsing;

    public class OrSymbol : Symbol
    {
        public Symbol[] Symbols { get; }

        public override SymbolKind Kind => SymbolKind.OneOf;

        public OrSymbol(IEnumerable<Symbol> symbols)
        {
            Symbols = symbols.ToArray();
        }

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseAny(parser, Symbols);
        }
    }
}