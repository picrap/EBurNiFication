namespace Eburnification.Symbols
{
    using System;
    using Parsing;

    public class SyntacticPrimary: Symbol<SyntacticPrimary>
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