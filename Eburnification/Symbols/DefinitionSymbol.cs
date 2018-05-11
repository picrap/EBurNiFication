// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class DefinitionSymbol : Symbol, IDefinitionSymbol
    {
        public override bool IsGapFreeSymbol => true;

        public override SymbolKind Kind => SymbolKind.Definition;

        public string Identifier { get; }
        public Symbol Value { get; }

        public DefinitionSymbol(string identifier, Symbol value)
        {
            Identifier = identifier;
            Value = value;
        }

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            // identifier is not used, we only look for the value
            return tokenizer.Parse(parser, Value);
        }

        public Token GetIdentifier(Token[] tokens)
        {
            return new Token(new LiteralSymbol(Identifier), Identifier, new Token[0]);
        }

        public Token GetValue(Token[] tokens)
        {
            return tokens[0];
        }
    }
}