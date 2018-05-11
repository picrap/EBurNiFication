// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class LookupSymbol : Symbol
    {
        public override bool IsGapFreeSymbol => true;

        public override SymbolKind Kind => SymbolKind.Neutral;

        private readonly string _identifier;
        private readonly IDictionary<string, Symbol> _definitions;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LookupSymbol" /> class.
        /// </summary>
        /// <param name="identifier">The identifier.</param>
        /// <param name="definitions">The definitions.</param>
        public LookupSymbol(string identifier, IDictionary<string, Symbol> definitions)
        {
            _identifier = identifier;
            _definitions = definitions;
        }

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            _definitions.TryGetValue(_identifier, out var symbol);
            return tokenizer.Parse(parser, symbol);
        }
    }
}