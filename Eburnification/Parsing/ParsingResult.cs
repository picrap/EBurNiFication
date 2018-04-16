// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Parsing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public struct ParsingResult
    {
        public static ParsingResult None = new ParsingResult(null);

        public static ParsingResult Empty = new ParsingResult(new Token[0]);

        /// <summary>
        /// Gets the tokens as an array. This is never null
        /// </summary>
        /// <value>
        /// An array of <see cref="Token"/>.
        /// </value>
        public IList<Token> Tokens { get; }

        // TODO: remove
        public Token Token => Tokens?.Single();

        /// <summary>
        /// Indicates whether there is a valid result.
        /// </summary>
        /// <value>
        ///   <c>true</c> if no result; otherwise, if result, <c>false</c>.
        /// </value>
        public bool IsNone => Tokens == null;

        private ParsingResult(Token[] tokens)
        {
            Tokens = tokens;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Token"/> to <see cref="ParsingResult"/>.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator ParsingResult(Token token) => new ParsingResult(new[] { token });

        /// <summary>
        /// Performs an implicit conversion from <see cref="Token[]"/> to <see cref="ParsingResult"/>.
        /// </summary>
        /// <param name="tokens">The tokens.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator ParsingResult(Token[] tokens) => new ParsingResult(tokens);

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Boolean"/> to <see cref="ParsingResult"/>.
        /// </summary>
        /// <param name="result">if set to <c>true</c> [result].</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator ParsingResult(bool result) => result ? Empty : None;

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
        public static ParsingResult operator ^(ParsingResult a, Func<ParsingResult> b)
        {
            return a.IsNone ? b() : a;
        }
    }
}
