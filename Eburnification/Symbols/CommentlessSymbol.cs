// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parser;

    public class CommentlessSymbol : Symbol<CommentlessSymbol>
    {
        public override bool TryParse(Tokenizer tokenizer)
        {
            return TerminalCharacter.Instance.TryParse(tokenizer)
                   || MetaIdentifier.Instance.TryParse(tokenizer)
                   || Integer.Instance.TryParse(tokenizer)
                   || TerminalString.Instance.TryParse(tokenizer)
                   || SpecialSequence.Instance.TryParse(tokenizer);
        }
    }
}