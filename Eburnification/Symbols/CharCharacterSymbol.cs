// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parser;

    public abstract class CharCharacterSymbol : Symbol
    {
        protected abstract char Character { get; }

        public override bool TryParse(Tokenizer tokenizer)
        {
            return tokenizer.TryRead(Character);
        }
    }
}