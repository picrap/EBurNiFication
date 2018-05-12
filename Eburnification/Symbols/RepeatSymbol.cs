// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System;
    using Parsing;

    public class RepeatSymbol : Symbol
    {
        private readonly Symbol _symbol;

        public override SymbolKind Kind => SymbolKind.Repeat;

        public RepeatSymbol(Symbol symbol)
        {
            _symbol = symbol;
        }

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseSequence(parser, _symbol, 1, int.MaxValue);
        }
    }
}