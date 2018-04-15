// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Parsing
{
    using System.Collections.Generic;
    using System.Linq;
    using Symbols;

    public class Tokenizer
    {
        public Token Parse(Parser parser, Symbol symbol)
        {
            var state = parser.State;

            var tokens = symbol.TryParse(this, parser);
            if (tokens == null)
                return null;

            var capture = parser.GetCapture(state);
            return new Token(symbol, capture, tokens);
        }

        public Token[] ParseAll(Parser parser, IEnumerable<Token> tokens)
        {
            var state = parser.State;

            var resulTokens = new List<Token>();
            foreach (var token in tokens)
            {
                if (token == null)
                {
                    parser.State = state;
                    return null;
                }
                resulTokens.Add(token);
            }

            return resulTokens.ToArray();
        }

        public Token[] ParseAll(Parser parser, params Symbol[] symbols)
        {
            return ParseAll(parser, symbols.Select(s => Parse(parser, s)));
        }

        public Token ParseAny(Parser parser, params Symbol[] symbols)
        {
            foreach (var symbol in symbols)
            {
                var token = Parse(parser, symbol);
                if (token != null)
                    return token;
            }

            return null;
        }

        public IList<Token> ParseSequence(Parser parser, Symbol symbol, int max, bool strict = true)
        {
            var state = parser.State;

            var tokens = new List<Token>();

            int count = 0;
            for (; count < max; count++)
            {
                var token = Parse(parser, symbol);
                if (token == null)
                    break;
                tokens.Add(token);
            }

            // if max is reached, see if there is nothing behind
            // (in strict mode)
            if (strict && count == max)
            {
                if (Parse(parser, symbol) != null)
                {
                    parser.State = state;
                    return null;
                }
            }

            return tokens.ToArray();
        }

        public IList<Token> ParseSequence(Parser parser, Symbol symbol, int min, int max, bool strict = true)
        {
            var state = parser.State;

            var tokens = ParseSequence(parser, symbol, max, strict);
            if (tokens?.Count >= min)
                return tokens;

            parser.State = state;
            return null;
        }

        private IEnumerable<Token> GetQuoteSequenceTokens(Parser parser, Symbol startSymbol, Symbol terminalCharacter, Symbol endSymbol)
        {
            yield return Parse(parser, startSymbol);
            var firstTerminalCharacters = ParseSequence(parser, terminalCharacter, int.MaxValue);
            if (firstTerminalCharacters == null)
                yield break;
            foreach (var token in firstTerminalCharacters)
                yield return token;
            yield return Parse(parser, endSymbol);
        }

        public IList<Token> ParseQuoteSequence(Parser parser, Symbol startSymbol, Symbol terminalCharacter, Symbol endSymbol)
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
        public Token ParseException(Parser parser, Symbol includeSymbol, Symbol exceptSymbol)
        {
            var state = parser.State;

            var includedToken = Parse(parser, includeSymbol);
            if (includedToken == null)
                return null;

            var innerParser = parser.CreateParser(includedToken.Value);
            var excludedToken = Parse(innerParser, exceptSymbol);
            if (excludedToken != null && innerParser.IsEnd)
            {
                parser.State = state;
                return null;
            }

            return includedToken;
        }
    }
}
