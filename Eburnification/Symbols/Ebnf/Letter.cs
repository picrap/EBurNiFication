// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    public class Letter : Symbol<Letter>
    {
        public override SymbolKind Kind => SymbolKind.Literal;

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return parser.TryRead(char.IsLetter);
        }
    }
}