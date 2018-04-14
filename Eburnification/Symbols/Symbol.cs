// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System;
    using Parsing;

    public abstract class Symbol
    {
        /// <summary>
        ///     Tries to parse symbol from current tokenizer.
        /// </summary>
        /// <param name="parser">The tokenizer.</param>
        /// <returns></returns>
        public abstract bool TryParse(Parser parser);

        protected bool TryParse(Parser parser, Predicate<Parser> tryParse)
        {
            var s = parser.State;
            var result = tryParse(parser);
            if (!result)
                parser.State = s;
            return result;
        }

        protected int? TryParseSequence(Parser parser, Symbol symbol, int max = int.MaxValue, bool strict = true)
        {
            int count = 0;
            for (; count < max; count++)
            {
                var parsed = symbol.TryParse(parser);
                if (!parsed)
                    break;
            }

            // if max is reached, see if there is nothing behind
            if (strict && count == max)
            {
                var s = parser.State;
                if (symbol.TryParse(parser))
                {
                    parser.State = s;
                    return null;
                }
            }

            return count;
        }

        protected int? TryParseSequence(Parser parser, Symbol symbol, int min, int max, bool strict = true)
        {
            var s = parser.State;
            var count = TryParseSequence(parser, symbol, max, strict);
            if (count >= min)
                return count;

            parser.State = s;
            return null;
        }
    }

    public abstract class Symbol<TSymbol> : Symbol
        where TSymbol : Symbol<TSymbol>, new()
    {
        private static TSymbol _instance;

        /// <summary>
        /// Gets a default instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static TSymbol Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new TSymbol();
                return _instance;
            }
        }
    }
}