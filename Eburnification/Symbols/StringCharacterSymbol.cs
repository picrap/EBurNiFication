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
            return parser.TryRead(Character) ? NoToken() : null;
        }
    }
}
