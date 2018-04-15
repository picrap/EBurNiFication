// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Parsing
{
    using System.Collections.Generic;
    using System.Linq;
    using Symbols;

    public class Tokenizer
    {
        public AnyToken Parse(Parser parser, Symbol symbol)
        {
            var state = parser.State;

            var anyToken = symbol.TryParse(this, parser);
            if (anyToken.IsNone)
                return anyToken;

            var capture = parser.GetCapture(state);

            return new Token(symbol, capture, anyToken.Tokens);
        }

        public AnyToken ParseAll(Parser parser, IEnumerable<AnyToken> anyTokens)
        {
            var state = parser.State;

            var tokens = new List<Token>();
            foreach (var anyToken in anyTokens)
            {
                if (anyToken.IsNone)
                {
                    parser.State = state;
                    return AnyToken.None;
                }
                tokens.AddRange(anyToken.Tokens);
            }

            return tokens.ToArray();
        }

        public AnyToken ParseAll(Parser parser, params Symbol[] symbols)
        {
            return ParseAll(parser, symbols.Select(s => Parse(parser, s)));
        }

        public AnyToken ParseAny(Parser parser, params Symbol[] symbols)
        {
            foreach (var symbol in symbols)
            {
                var token = Parse(parser, symbol);
                if (!token.IsNone)
                    return token;
            }

            return AnyToken.None;
        }

        public AnyToken ParseSequence(Parser parser, Symbol symbol, int max, bool strict = true)
        {
            var state = parser.State;

            var tokens = new List<Token>();

            int count = 0;
            for (; count < max; count++)
            {
                var token = Parse(parser, symbol);
                if (token.IsNone)
                    break;
                tokens.AddRange(token.Tokens);
            }

            // if max is reached, see if there is nothing behind
            // (in strict mode)
            if (strict && count == max)
            {
                if (!Parse(parser, symbol).IsNone)
                {
                    parser.State = state;
                    return AnyToken.None;
                }
            }

            return tokens.ToArray();
        }

        public AnyToken ParseSequence(Parser parser, Symbol symbol, int min, int max, bool strict = true)
        {
            var state = parser.State;

            var anyToken = ParseSequence(parser, symbol, max, strict);
            if (anyToken.Tokens.Count >= min)
                return anyToken;

            parser.State = state;
            return AnyToken.None;
        }

        private IEnumerable<AnyToken> GetQuoteSequenceTokens(Parser parser, Symbol startSymbol, Symbol terminalCharacter, Symbol endSymbol)
        {
            yield return Parse(parser, startSymbol);
            yield return ParseSequence(parser, terminalCharacter, int.MaxValue);
            yield return Parse(parser, endSymbol);
        }

        public AnyToken ParseQuoteSequence(Parser parser, Symbol startSymbol, Symbol terminalCharacter, Symbol endSymbol)
        {
            return ParseAll(parser, GetQuoteSequenceTokens(parser, startSymbol, terminalCharacter, endSymbol));
        }

        /// <summary>
        /// Parses a symbol, only if it excludes another symbol.
        /// </summary>
        /// <param name="parser">The parser.</param>
        /// <param name="includeSymbol">The include symbol.</param>
        /// <param name="exceptSymbol">The except symbol.</param>
        /// <returns></returns>
        public AnyToken ParseException(Parser parser, Symbol includeSymbol, Symbol exceptSymbol)
        {
            var state = parser.State;

            var includedToken = Parse(parser, includeSymbol);
            if (includedToken.IsNone)
                return AnyToken.None;

            var innerParser = parser.CreateSubParser(state);
            var excludedToken = Parse(innerParser, exceptSymbol);
            if (!excludedToken.IsNone && innerParser.IsEnd)
            {
                parser.State = state;
                return AnyToken.None;
            }

            return includedToken;
        }
    }
}
