// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    public class RepeatedSequence : Symbol<RepeatedSequence>, IRepeatSymbol
    {
        public override SymbolKind Kind => SymbolKind.Repeat;

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseAll(parser, StartRepeatSymbol.Instance, DefinitionsList.Instance, EndRepeatSymbol.Instance);
        }

        public Token GetSymbol(Token[] tokens)
        {
            return tokens[1];
        }
    }
}