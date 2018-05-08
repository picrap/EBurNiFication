// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Parsing
{
    using System.Collections.Generic;
    using System.Linq;
    using Symbols;

    public class Tokenizer
    {
        public Token Parse(string s) => Parse(s, Syntax.Instance);

        public Token Parse(string s, Symbol symbol)
        {
            var parser = new TextParser(s);
            var result = Parse(parser, symbol);
            if (parser.IsEnd)
                return result.Tokens?.Single();
            return null;
        }

        public ParsingResult Parse(Parser parser, Symbol symbol)
        {
            if (symbol.IsGapFreeSymbol)
                return ParseGapFree(parser, symbol);
            return ParseNonGapFree(parser, symbol);
        }

        private ParsingResult ParseGapFree(Parser parser, Symbol symbol)
        {
            var state = parser.State;
            GapSeparator.Instance.TryParse(this, parser);
            var parsingResult = ParseNonGapFree(parser, symbol);
            GapSeparator.Instance.TryParse(this, parser);
            if (parsingResult.IsNone)
                parser.State = state;
            return parsingResult;
        }

        private ParsingResult ParseNonGapFree(Parser parser, Symbol symbol)
        {
            var state = parser.State;

            var parsingResult = symbol.TryParse(this, parser);
            if (parsingResult.IsNone)
                return parsingResult;

            var capture = parser.GetCapture(state);

            // optimization
            var significantTokens = parsingResult.Tokens.Where(t => t.Symbol.IsSignificant).ToArray();
            if (significantTokens.Length == 1)
            {
                var singleToken = significantTokens[0];
                if (capture == singleToken.Value)
                    return singleToken;
            }

            // otherwise, keep it as it was
            return new Token(symbol, capture, significantTokens);
        }

        public ParsingResult ParseAll(Parser parser, IEnumerable<ParsingResult> allResults)
        {
            var state = parser.State;

            var tokens = new List<Token>();
            foreach (var parsingResult in allResults)
            {
                if (parsingResult.IsNone)
                {
                    parser.State = state;
                    return ParsingResult.None;
                }

                tokens.AddRange(parsingResult.Tokens);
            }

            return tokens.ToArray();
        }

        public ParsingResult ParseAny(Parser parser, IEnumerable<ParsingResult> anyResults)
        {
            var state = parser.State;

            foreach (var parsingResult in anyResults)
            {
                if (!parsingResult.IsNone)
                    return parsingResult;

                parser.State = state;
            }

            return ParsingResult.None;
        }

        public ParsingResult ParseAll(Parser parser, params Symbol[] symbols)
        {
            return ParseAll(parser, symbols.Select(s => Parse(parser, s)));
        }

        public ParsingResult ParseAny(Parser parser, params Symbol[] symbols)
        {
            foreach (var symbol in symbols)
            {
                var token = Parse(parser, symbol);
                if (!token.IsNone)
                    return token;
            }

            return ParsingResult.None;
        }

        public ParsingResult ParseSequence(Parser parser, Symbol symbol, int max, bool strict = true)
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
                    return ParsingResult.None;
                }
            }

            return tokens.ToArray();
        }

        public ParsingResult ParseSequence(Parser parser, Symbol symbol, int min, int max, bool strict = true)
        {
            var state = parser.State;

            var parsingResult = ParseSequence(parser, symbol, max, strict);
            if (parsingResult.Tokens.Count >= min)
                return parsingResult;

            parser.State = state;
            return ParsingResult.None;
        }

        private IEnumerable<ParsingResult> GetQuoteSequenceTokens(Parser parser, Symbol startSymbol, Symbol terminalCharacter, Symbol endSymbol)
        {
            yield return Parse(parser, startSymbol);
            yield return ParseSequence(parser, terminalCharacter, int.MaxValue);
            yield return Parse(parser, endSymbol);
        }

        public ParsingResult ParseQuoteSequence(Parser parser, Symbol startSymbol, Symbol terminalCharacter, Symbol endSymbol)
        {
            return ParseAll(parser, GetQuoteSequenceTokens(parser, startSymbol, terminalCharacter, endSymbol));
        }

        /// <summary>
        ///     Parses a symbol, only if it excludes another symbol.
        /// </summary>
        /// <param name="parser">The parser.</param>
        /// <param name="includeSymbol">The include symbol.</param>
        /// <param name="exceptSymbol">The except symbol.</param>
        /// <returns></returns>
        public ParsingResult ParseException(Parser parser, Symbol includeSymbol, Symbol exceptSymbol)
        {
            var state = parser.State;

            var includedToken = Parse(parser, includeSymbol);
            if (includedToken.IsNone)
                return ParsingResult.None;

            var innerParser = parser.CreateSubParser(state);
            var excludedToken = Parse(innerParser, exceptSymbol);
            if (!excludedToken.IsNone && innerParser.IsEnd)
            {
                parser.State = state;
                return ParsingResult.None;
            }

            return includedToken;
        }

        public ParsingResult ParseSeparated(Parser parser, Symbol symbol, Symbol separator, int min = 1)
        {
            var state = parser.State;

            var results = new List<Token>();
            for (var count = 0; ; count++)
            {
                // on next loop, expect separator,
                // otherwise this means end
                if (count > 0)
                {
                    if (separator.TryParse(this, parser).IsNone)
                    {
                        if (count < min)
                        {
                            parser.State = state;
                            return ParsingResult.None;
                        }

                        break;
                    }
                }

                var parsingResult = symbol.TryParse(this, parser);
                if (parsingResult.IsNone)
                {
                    parser.State = state;
                    return ParsingResult.None;
                }

                results.AddRange(parsingResult.Tokens);
            }

            return results;
        }
    }
}