// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class CommentSymbol : Symbol<CommentSymbol>
    {
        public override bool TryParse(Parser parser)
        {
            return BracketedTextualComment.Instance.TryParse(parser)
                   || CommentlessSymbol.Instance.TryParse(parser)
                   || OtherCharacter.Instance.TryParse(parser);
        }
    }
}