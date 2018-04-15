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

        public IList<Token> Tokens => _anyToken as IList<Token> ?? new[] { (Token)_anyToken }; // cast here to be sure there won't be any null (there should not)
        public Token Token => _anyToken as Token;

        public bool IsNone => _anyToken == null;

        private AnyToken(object token)
        {
            _anyToken = token;
        }

        public static implicit operator AnyToken(Token token) => new AnyToken(token);
        public static implicit operator AnyToken(Token[] tokens) => new AnyToken(tokens);

        public static AnyToken operator ^(AnyToken a, Func<AnyToken> b)
        {
            return a.IsNone ? b() : a;
        }
    }
}
