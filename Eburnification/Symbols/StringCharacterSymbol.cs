// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public abstract class StringCharacterSymbol<TSymbol> : Symbol<TSymbol>
        where TSymbol : Symbol<TSymbol>, new()
    {
        protected abstract string Character { get; }

        public override bool IsGapFreeSymbol => true;

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            if (IsGapFreeSymbol)
                tokenizer.Parse(parser, GapSeparator.Instance);
            return parser.TryRead(Character);
        }
    }
}