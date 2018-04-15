// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System;
    using System.Collections.Generic;
    using Parsing;

    public abstract class Symbol
    {
        /// <summary>
        ///     Tries to parse symbol from current tokenizer.
        /// </summary>
        /// <param name="tokenizer"></param>
        /// <param name="parser">The tokenizer.</param>
        /// <returns></returns>
        public abstract IList<Token> TryParse(Tokenizer tokenizer, Parser parser);

        protected IList<Token> TryParse(Tokenizer tokenizer, Parser parser, Func<Tokenizer, Parser, IList<Token>> tryParse)
        {
            var state = parser.State;

            var token = tryParse(tokenizer, parser);
            if (token == null)
                parser.State = state;

            return token;
        }

        protected static Token[] ToTokens(Token token)
        {
            if (token == null)
                return null;
            return new[] { token };
        }

        protected static Token[] NoToken() => new Token[0];
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