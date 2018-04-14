// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parser;

    public class TerminalString : Symbol<TerminalString>
    {
        public override bool TryParse(Tokenizer tokenizer)
        {
            return TryParse(tokenizer, TryParseFirstTerminalString)
                   || TryParse(tokenizer, TryParseSecondTerminalString);
        }

        private bool TryParseFirstTerminalString(Tokenizer tokenizer)
        {
            return FirstQuoteSymbol.Instance.TryParse(tokenizer)
                   && TryParseSequence(tokenizer, FirstTerminalCharacter.Instance).HasValue
                   && FirstQuoteSymbol.Instance.TryParse(tokenizer);
        }

        private bool TryParseSecondTerminalString(Tokenizer tokenizer)
        {
            return SecondQuoteSymbol.Instance.TryParse(tokenizer)
                   && TryParseSequence(tokenizer, SecondTerminalCharacter.Instance).HasValue
                   && SecondQuoteSymbol.Instance.TryParse(tokenizer);
        }
    }
}
