// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parser;

    public class BracketedTextualComment : Symbol<BracketedTextualComment>
    {
        public override bool TryParse(Tokenizer tokenizer)
        {
            return TryParse(tokenizer, TryParseBracketedTextualComment);
        }

        private bool TryParseBracketedTextualComment(Tokenizer tokenizer)
        {
            return StartCommentSymbol.Instance.TryParse(tokenizer)
                   && TryParseSequence(tokenizer, CommentSymbol.Instance, 0, int.MaxValue).HasValue
                   && EndCommentSymbol.Instance.TryParse(tokenizer);
        }
    }
}