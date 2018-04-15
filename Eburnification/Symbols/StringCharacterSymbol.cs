// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public abstract class StringCharacterSymbol<TSymbol> : Symbol<TSymbol>
        where TSymbol : Symbol<TSymbol>, new()
    {
        protected abstract string Character { get; }

        public override IList<Token> TryParse(Tokenizer tokenizer, Parser parser)
        {
            return ToTokens(parser.TryRead(Character));
        }
    }
}