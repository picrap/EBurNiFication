// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    /// <summary>
    /// commentless-symbol (§6.5)
    /// </summary>
    public class CommentlessSymbol : Symbol<CommentlessSymbol>
    {
        public override IList<Token> TryParse(Tokenizer tokenizer, Parser parser)
        {
            return ToTokens(tokenizer.ParseAny(parser,
                TerminalCharacter.Instance,
                MetaIdentifier.Instance,
                Integer.Instance,
                TerminalString.Instance,
                SpecialSequence.Instance
            ));
        }
    }
}