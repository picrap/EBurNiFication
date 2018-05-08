// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    /// <summary>
    ///     syntactic-exception (§4.7)
    ///     This one has no default instance
    /// </summary>
    /// <seealso cref="Eburnification.Symbols.Symbol" />
    public class SyntacticException : Symbol<SyntacticException>
    {
        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.Parse(parser, SyntacticFactor.Instance);
        }
    }
}