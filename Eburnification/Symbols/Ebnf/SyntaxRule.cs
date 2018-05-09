// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols.Ebnf
{
    using Parsing;

    public class SyntaxRule : Symbol<SyntaxRule>
    {
        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseAll(parser, MetaIdentifier.Instance, DefiningSymbol.Instance, DefinitionsList.Instance, TerminatorSymbol.Instance);
        }
    }
}