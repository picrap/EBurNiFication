// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    /// <summary>
    ///     syntactic-exception (§4.7)
    ///     This one has no default instance
    /// </summary>
    /// <seealso cref="Eburnification.Symbols.Symbol" />
    public class SyntacticException : Symbol
    {
        private readonly Symbol _included;
        private readonly Symbol _excluded;

        public SyntacticException(Symbol included, Symbol excluded)
        {
            _included = included;
            _excluded = excluded;
        }

        public override IList<Token> TryParse(Tokenizer tokenizer, Parser parser)
        {
            return ToTokens(tokenizer.ParseException(parser, _included, _excluded));
        }
    }
}