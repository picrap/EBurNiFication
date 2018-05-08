// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class DefinitionsList : Symbol<DefinitionsList>
    {
        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseSeparated(parser, SingleDefinition.Instance, DefinitionSeparatorSymbol.Instance);
        }
    }
}