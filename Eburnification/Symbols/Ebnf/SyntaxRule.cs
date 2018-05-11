// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    public class SyntaxRule : Symbol<SyntaxRule>, IDefinitionSymbol
    {
        public override SymbolKind Kind => SymbolKind.Definition;

        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseAll(parser, MetaIdentifier.Instance, DefiningSymbol.Instance, DefinitionsList.Instance, TerminatorSymbol.Instance);
        }

        public Token GetIdentifier(Token[] tokens)
        {
            return tokens[0];
        }

        public Token GetValue(Token[] tokens)
        {
            return tokens[2];
        }
    }
}