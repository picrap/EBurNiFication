// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    /// <summary>
    ///     gap-free-symbol (§6.3)
    /// </summary>
    public class GapFreeSymbol : Symbol<GapFreeSymbol>
    {
        public override AnyToken TryParse(Tokenizer tokenizer, Parser parser)
        {
            return TryParseTerminalNoQuote(tokenizer, parser)
                   ^ (() => tokenizer.Parse(parser, TerminalString.Instance));
        }

        private static AnyToken TryParseTerminalNoQuote(Tokenizer tokenizer, Parser parser)
        {
            var state = parser.State;

            var anyToken = tokenizer.Parse(parser, TerminalCharacter.Instance);
            if (anyToken.IsNone)
                return AnyToken.None;

            var textParser = parser.CreateParser(parser.GetCapture(state));
            if (!tokenizer.ParseAny(textParser, FirstQuoteSymbol.Instance, SecondQuoteSymbol.Instance).IsNone && textParser.Peek() == null)
            {
                parser.State = state;
                return AnyToken.None;
            }

            return anyToken;
        }
    }
}
