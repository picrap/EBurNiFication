// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class TerminalString : Symbol<TerminalString>
    {
        public override bool TryParse(Parser parser)
        {
            return TryParse(parser, TryParseFirstTerminalString)
                   || TryParse(parser, TryParseSecondTerminalString);
        }

        private bool TryParseFirstTerminalString(Parser parser)
        {
            return FirstQuoteSymbol.Instance.TryParse(parser)
                   && TryParseSequence(parser, FirstTerminalCharacter.Instance).HasValue
                   && FirstQuoteSymbol.Instance.TryParse(parser);
        }

        private bool TryParseSecondTerminalString(Parser parser)
        {
            return SecondQuoteSymbol.Instance.TryParse(parser)
                   && TryParseSequence(parser, SecondTerminalCharacter.Instance).HasValue
                   && SecondQuoteSymbol.Instance.TryParse(parser);
        }
    }
}
