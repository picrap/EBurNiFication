// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class SyntacticPrimary : Symbol<SyntacticPrimary>
    {
        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseAny(parser,
                OptionalSequence.Instance,
                RepeatedSequence.Instance,
                GroupedSequence.Instance,
                MetaIdentifier.Instance,
                TerminalString.Instance,
                SpecialSequence.Instance,
                EmptySequence.Instance);
        }
    }
}