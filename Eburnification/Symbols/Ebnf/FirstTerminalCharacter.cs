// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    public class FirstTerminalCharacter : Symbol<FirstTerminalCharacter>
    {
        public override SymbolKind Kind => SymbolKind.Literal;

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return parser.TryRead(c => c != '\'');
        }
    }
}