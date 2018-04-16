// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public abstract class CharCharacterSymbol<TSymbol> : Symbol<TSymbol>
        where TSymbol : Symbol<TSymbol>, new()
    {
        protected abstract char Character { get; }

        public override AnyToken TryParse(Tokenizer tokenizer, Parser parser)
        {
            return parser.TryRead(Character);
        }
    }
}