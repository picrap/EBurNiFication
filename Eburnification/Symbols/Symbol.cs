// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System;
    using Parser;

    public abstract class Symbol
    {
        /// <summary>
        ///     Tries to parse symbol from current tokenizer.
        /// </summary>
        /// <param name="tokenizer">The tokenizer.</param>
        /// <returns></returns>
        public abstract bool TryParse(Tokenizer tokenizer);

        protected bool TryParse(Tokenizer tokenizer, Predicate<Tokenizer> tryParse)
        {
            var s = tokenizer.State;
            var result = tryParse(tokenizer);
            if (!result)
                tokenizer.State = s;
            return result;
        }

        protected int? TryParseSequence(Tokenizer tokenizer, Symbol symbol, int max = int.MaxValue, bool strict = true)
        {
            int count = 0;
            for (; count < max; count++)
            {
                var parsed = symbol.TryParse(tokenizer);
                if (!parsed)
                    break;
            }

            // if max is reached, see if there is nothing behind
            if (strict && count == max)
            {
                var s = tokenizer.State;
                if (symbol.TryParse(tokenizer))
                {
                    tokenizer.State = s;
                    return null;
                }
            }

            return count;
        }

        protected int? TryParseSequence(Tokenizer tokenizer, Symbol symbol, int min, int max, bool strict = true)
        {
            var s = tokenizer.State;
            var count = TryParseSequence(tokenizer, symbol, max, strict);
            if (count >= min)
                return count;

            tokenizer.State = s;
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