namespace Eburnification.Symbols
{
    using Parsing;

    public abstract class StringCharacterSymbol<TSymbol> : Symbol<TSymbol>
        where TSymbol : Symbol<TSymbol>, new()
    {
        protected abstract string Character { get; }

        public override bool TryParse(Parser parser)
        {
            return parser.TryRead(Character);
        }
    }
}