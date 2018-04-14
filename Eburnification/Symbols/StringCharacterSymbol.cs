namespace Eburnification.Symbols
{
    using Parser;

    public abstract class StringCharacterSymbol<TSymbol> : Symbol<TSymbol>
        where TSymbol : Symbol<TSymbol>, new()
    {
        protected abstract string Character { get; }

        public override bool TryParse(Tokenizer tokenizer)
        {
            return tokenizer.TryRead(Character);
        }
    }
}