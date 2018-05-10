// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    public class Integer : Symbol<Integer>
    {
        public override SymbolKind Kind => SymbolKind.Literal;

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseSequence(parser, DecimalDigit.Instance, 1, int.MaxValue);
        }
    }
}