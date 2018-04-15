// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    /// <summary>
    /// Base class for all symbols.
    /// Provides wrappers to convert results to Tokens list
    /// </summary>
    public abstract class Symbol
    {
        private static readonly Token[] NoToken = new Token[0];

        /// <summary>
        ///     Tries to parse symbol from current tokenizer.
        /// </summary>
        /// <param name="tokenizer"></param>
        /// <param name="parser">The tokenizer.</param>
        /// <returns></returns>
        public abstract AnyToken TryParse(Tokenizer tokenizer, Parser parser);

        protected static AnyToken ToTokens(Token token)
        {
            return token;
        }

        protected static AnyToken ToTokens(bool singleResult)
        {
            return singleResult ? AnyToken.Empty : AnyToken.None;
        }
    }

    /// <summary>
    /// Each <see cref="Symbol{TSymbol}"/> has a default instance, that we create here.
    /// This is a pure expression of laziness
    /// </summary>
    /// <typeparam name="TSymbol">The type of the symbol.</typeparam>
    public abstract class Symbol<TSymbol> : Symbol
        where TSymbol : Symbol<TSymbol>, new()
    {
        private static TSymbol _instance;

        /// <summary>
        ///     Gets a default instance.
        /// </summary>
        /// <value>
        ///     The instance.
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
