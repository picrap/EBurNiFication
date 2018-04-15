// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using System.Collections.Generic;
    using Parsing;

    public class CommentSymbol : Symbol<CommentSymbol>
    {
        public override IList<Token> TryParse(Tokenizer tokenizer, Parser parser)
        {
            return ToTokens(tokenizer.ParseAny(parser,
                BracketedTextualComment.Instance,
                CommentlessSymbol.Instance,
                OtherCharacter.Instance
            ));
        }
    }
}