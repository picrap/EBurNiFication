// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    /// <summary>
    ///     gap-free-symbol (§6.3)
    /// </summary>
    public class GapFreeSymbol : Symbol<GapFreeSymbol>
    {
        public override IList<Token> TryParse(Tokenizer tokenizer, Parser parser)
        {
            return ToTokens(TryParseTerminalNoQuote(tokenizer, parser)
                            ?? tokenizer.Parse(parser, TerminalString.Instance));
        }

        private static Token TryParseTerminalNoQuote(Tokenizer tokenizer, Parser parser)
        {
            var state = parser.State;
            var token = tokenizer.Parse(parser, TerminalCharacter.Instance);
            if (token == null)
                return null;
            var textParser = new TextParser(token.Value);
            if (tokenizer.ParseAny(textParser, FirstQuoteSymbol.Instance, SecondQuoteSymbol.Instance) != null && textParser.Peek() == null)
            {
                parser.State = state;
                return null;
            }

            return token;
        }
    }
}