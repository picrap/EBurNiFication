// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class CommentlessSymbol : Symbol<CommentlessSymbol>
    {
        public override bool TryParse(Parser parser)
        {
            return TerminalCharacter.Instance.TryParse(parser)
                   || MetaIdentifier.Instance.TryParse(parser)
                   || Integer.Instance.TryParse(parser)
                   || TerminalString.Instance.TryParse(parser)
                   || SpecialSequence.Instance.TryParse(parser);
        }
    }
}