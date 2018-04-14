// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parser;

    public class TerminalString : Symbol
    {
        private readonly FirstQuoteSymbol _firstQuoteSymbol = new FirstQuoteSymbol();
        private readonly SecondQuoteSymbol _secondQuoteSymbol = new SecondQuoteSymbol();
        private readonly FirstTerminalCharacter _firstTerminalCharacter = new FirstTerminalCharacter();
        private readonly SecondTerminalCharacter _secondTerminalCharacter = new SecondTerminalCharacter();

        public override bool TryParse(Tokenizer tokenizer)
        {
            return TryParse(tokenizer, TryParseFirstTerminalString)
                   || TryParse(tokenizer, TryParseSecondTerminalString);
        }

        private bool TryParseFirstTerminalString(Tokenizer tokenizer)
        {
            return _firstQuoteSymbol.TryParse(tokenizer)
                   && TryParseSequence(tokenizer, _firstTerminalCharacter).HasValue
                   && _firstQuoteSymbol.TryParse(tokenizer);
        }

        private bool TryParseSecondTerminalString(Tokenizer tokenizer)
        {
            return _secondQuoteSymbol.TryParse(tokenizer)
                   && TryParseSequence(tokenizer, _secondTerminalCharacter).HasValue
                   && _secondQuoteSymbol.TryParse(tokenizer);
        }
    }
}