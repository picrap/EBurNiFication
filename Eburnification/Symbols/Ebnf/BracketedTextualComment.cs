// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    public class BracketedTextualComment : Symbol<BracketedTextualComment>
    {
        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseQuoteSequence(parser, StartCommentSymbol.Instance, CommentSymbol.Instance, EndCommentSymbol.Instance);
        }
    }
}