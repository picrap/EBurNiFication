// This is EBurNiFication - https://github.com/picrap/EBurNiFication - MIT License

namespace Eburnification.Symbols
{
    using Parsing;

    public class GroupedSequence : Symbol<GroupedSequence>
    {
        public override ParsingResult TryParse(Tokenizer tokenizer, Parser parser)
        {
            return tokenizer.ParseAll(parser, StartGroupSymbol.Instance, DefinitionsList.Instance, EndGroupSymbol.Instance);
        }
    }
}