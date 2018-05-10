// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class DefinitionSymbol : Symbol
    {
        public Symbol Identifier { get; }
        public Symbol Value { get; }

        public override SymbolKind Kind => SymbolKind.Definition;

        public DefinitionSymbol(Symbol identifier, Symbol value)
        {
            Identifier = identifier;
            Value = value;
        }

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            throw new System.NotImplementedException();
        }
    }
}