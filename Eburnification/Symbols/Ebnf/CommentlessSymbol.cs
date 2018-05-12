// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    /// <summary>
    ///     commentless-symbol (§6.5)
    /// </summary>
    public class CommentlessSymbol : Symbol<CommentlessSymbol>
    {
        private readonly Symbol _except = new OrSymbol(Letter.Instance, DecimalDigit.Instance, FirstQuoteSymbol.Instance, SecondQuoteSymbol.Instance,
            StartCommentSymbol.Instance, EndCommentSymbol.Instance, SpecialSequenceSymbol.Instance, OtherCharacter.Instance);

        private readonly Symbol _terminalCharacterExcept;

        public CommentlessSymbol()
        {
            _terminalCharacterExcept = new Symbols.ExceptSymbol(TerminalCharacter.Instance, _except);
        }

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseAny(parser,
                _terminalCharacterExcept,
                MetaIdentifier.Instance,
                Integer.Instance,
                TerminalString.Instance,
                SpecialSequence.Instance
            );
        }
    }
}