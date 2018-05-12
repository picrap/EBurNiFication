// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    /// <summary>
    ///     special-sequence (§5.11)
    /// </summary>
    public class SpecialSequence : Symbol<SpecialSequence>
    {
        public override bool IsCommentlessSymbol => true;

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseQuoteSequence(parser, SpecialSequenceSymbol.Instance, SpecialSequenceCharacter.Instance, SpecialSequenceSymbol.Instance);
        }
    }
}