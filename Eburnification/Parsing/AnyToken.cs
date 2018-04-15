// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Parsing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public struct AnyToken
    {
        public static AnyToken None = new AnyToken(null);

        public static AnyToken Empty = new AnyToken(new Token[0]);

        private readonly object _anyToken;

        /// <summary>
        /// Gets a single <see cref="Token"/> or null if there is no result or the result is an array.
        /// Currently only used in test, so will be removed one day
        /// </summary>
        /// <value>
        /// The token.
        /// </value>
        public Token Token => _anyToken as Token;

        /// <summary>
        /// Gets the tokens as an array. This is never null
        /// </summary>
        /// <value>
        /// An array of <see cref="Token"/>.
        /// </value>
        public IList<Token> Tokens => _anyToken as IList<Token> ?? new[] { (Token)_anyToken }; // cast here to be sure there won't be any null (there should not)

        /// <summary>
        /// Indicates whether there is a valid result.
        /// </summary>
        /// <value>
        ///   <c>true</c> if no result; otherwise, if result, <c>false</c>.
        /// </value>
        public bool IsNone => _anyToken == null;

        private AnyToken(object token)
        {
            _anyToken = token;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Token"/> to <see cref="AnyToken"/>.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator AnyToken(Token token) => new AnyToken(token);
        /// <summary>
        /// Performs an implicit conversion from <see cref="Token[]"/> to <see cref="AnyToken"/>.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator AnyToken(Token[] tokens) => new AnyToken(tokens);

        /// <summary>
        /// Implements the operator ^.
        /// This is a lazy or.
        /// If the <see cref="a"/> token is not valid, then the <see cref="b"/> method is run
        /// and its result returned
        /// </summary>
        /// <param name="a">a.</param>
        /// <param name="b">The b.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static AnyToken operator ^(AnyToken a, Func<AnyToken> b)
        {
            return a.IsNone ? b() : a;
        }
    }
}
