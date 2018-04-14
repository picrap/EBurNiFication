// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class BracketedTextualComment : Symbol<BracketedTextualComment>
    {
        public override bool TryParse(Parser parser)
        {
            return TryParse(parser, TryParseBracketedTextualComment);
        }

        private bool TryParseBracketedTextualComment(Parser parser)
        {
            return StartCommentSymbol.Instance.TryParse(parser)
                   && TryParseSequence(parser, CommentSymbol.Instance, 0, int.MaxValue).HasValue
                   && EndCommentSymbol.Instance.TryParse(parser);
        }
    }
}