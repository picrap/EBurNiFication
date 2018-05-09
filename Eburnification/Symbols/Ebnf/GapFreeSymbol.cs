// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    /// <summary>
    ///     gap-free-symbol (§6.3)
    /// </summary>
    public class GapFreeSymbol : Symbol<GapFreeSymbol>
    {
        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return TryParseTerminalNoQuote(tokenizer, parser)
                   ^ (() => tokenizer.Parse(parser, TerminalString.Instance));
        }

        private static ParsingResult TryParseTerminalNoQuote(Tokenizer tokenizer, Parser parser)
        {
            var state = parser.State;

            var parsingResult = tokenizer.Parse(parser, TerminalCharacter.Instance);
            if (parsingResult.IsNone)
                return ParsingResult.None;

            var textParser = parser.CreateSubParser(state);
            if (!tokenizer.ParseAny(textParser, FirstQuoteSymbol.Instance, SecondQuoteSymbol.Instance).IsNone && textParser.Peek() == null)
            {
                parser.State = state;
                return ParsingResult.None;
            }

            return parsingResult;
        }
    }
}