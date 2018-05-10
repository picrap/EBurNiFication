// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using System.Linq;
    using Parsing;

    public class AndSymbol : Symbol
    {
        public Symbol[] Symbols { get; }

        public override SymbolKind Kind => SymbolKind.AllOf;

        public AndSymbol(IEnumerable<Symbol> symbols)
        {
            Symbols = symbols.ToArray();
        }

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseAll(parser, Symbols);
        }
    }
}
