// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    public class DefinitionsList : Symbol<DefinitionsList>
    {
        public override SymbolKind Kind => SymbolKind.OneOf;

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseSeparated(parser, SingleDefinition.Instance, DefinitionSeparatorSymbol.Instance);
        }
    }
}