// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parser;

    public class CommentSymbol : Symbol<CommentSymbol>
    {
        public override bool TryParse(Tokenizer tokenizer)
        {
            return BracketedTextualComment.Instance.TryParse(tokenizer)
                   || CommentlessSymbol.Instance.TryParse(tokenizer)
                   || OtherCharacter.Instance.TryParse(tokenizer);
        }
    }
}